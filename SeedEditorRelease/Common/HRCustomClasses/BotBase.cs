using HREngine.API;
using HREngine.API.Utilities;
using System;
using System.Collections.Generic;

namespace HREngine.Bots
{
   public class PossibleTurnAttack
   {
      public int Cost;
      public int Attack;
      public int NeededAttack;
      public List<HRCard> Cards;
   }

   public abstract class BotBase : API.IBot
   {
      public BotBase()
      {
         OnBattleLocalPlayerTurn = HandleBattleLocalPlayerTurnHandler;
         OnBattleMulliganPhase = HandleBattleMulliganPhase;
      }

      private void HandleBattleMulliganPhase()
      {
         if (HRMulligan.IsMulliganActive())
         {
            var list = HRCard.GetCards(HRPlayer.GetLocalPlayer(), HRCardZone.HAND);

            foreach (var item in list)
            {
               if (item.GetEntity().GetCost() >= 4)
               {
                  HRLog.Write("Rejecting Mulligan Card " + item.GetEntity().GetName() + " because it cost is >= 4.");
                  HRMulligan.ToggleCard(item);
               }
            }

            HRMulligan.EndMulligan();
         }
      }

      /// <summary>
      /// [EN]
      /// This handler is executed when the local player turn is active.
      ///
      /// [DE]
      /// Dieses Event wird ausgelöst wenn der Spieler am Zug ist.
      /// </summary>
      private void HandleBattleLocalPlayerTurnHandler()
      {
         try
         {
            SafeHandleBattleLocalPlayerTurnHandler();
         }
         catch (Exception Exception)
         {
            HRLog.Write(Exception.Message);
            HRLog.Write(Environment.StackTrace);
         }

         HRBattle.FinishRound();
      }

      protected virtual void SafeHandleBattleLocalPlayerTurnHandler()
      {
         try
         {
            TryHeal();
         }
         catch (Exception)
         {
            HRLog.Write("TryHeal caused an exception");
            throw;
         }

         try
         {
            TryPossibleWin();
         }
         catch (Exception)
         {
            HRLog.Write("TryPossibleWin caused an exception.");
            throw;
         }

         try
         {
            TrySpawnCharges();
         }
         catch (Exception)
         {
            HRLog.Write("TrySpawnCharges caused an exception.");
         }

         try
         {
            TrySpawnRest();
         }
         catch (Exception)
         {
            HRLog.Write("TrySpawnRest caused an exception");
            throw;
         }

         try
         {
            TryPossibleOneShots();
         }
         catch (Exception)
         {
            HRLog.Write("TryPossibleOneShots caused an exception.");
            throw;
         }

         // TryFight
         try
         {
            TryFight();
         }
         catch (Exception)
         {
            HRLog.Write("TryFight caused an exception");
            throw;
         }

         try
         {
            TryHeroPower();
         }
         catch (Exception)
         {
            HRLog.Write("TryHeroPower caused an exception");
            throw;
         }
      }

      protected virtual void TryHeal()
      {
         // PRIEST: Heal if Health < 18
         if (HRPlayer.GetLocalPlayer().GetRemainingHP() < 18 &&
            HRPlayer.GetLocalPlayer().GetClass() == HRClass.PRIEST)
         {
            try
            {
               TryHeroPower();
            }
            catch (Exception)
            {
               HRLog.Write("TryHeroPower caused an exception");
               throw;
            }
         }
      }

      protected virtual void TryHeroPower()
      {
         var nextMinion = GetMinionByPriority();
         if (nextMinion == null)
            nextMinion = HRPlayer.GetEnemyPlayer().GetHero().GetCard();

         // Warlock should not suicide.
         // FIX: https://github.com/Hearthcrawler/HREngine/issues/30
         if (HRPlayer.GetLocalPlayer().GetHero().GetClass() == HRClass.WARLOCK)
         {
            if (HRPlayer.GetLocalPlayer().GetRemainingHP() <= 10)
            {
               return;
            }
         }

         HRBattle.UseHeroPower(nextMinion.GetEntity());
      }

      protected virtual void TrySpawnRest()
      {
         var p = HRPlayer.GetLocalPlayer();

         List<HRCard> hand = HRCard.GetCards(p, HRCardZone.HAND);

         HRCard cTheCoin = null;

         foreach (var card in hand)
         {
            if (card.GetEntity().IsMinion() || card.GetEntity().IsSpell() || (!p.HasWeapon() && card.GetEntity().IsWeapon()))
            {
               // Skip "THE COIN"
               string CardID = card.GetEntity().GetCardId().ToUpper();
               if (CardID == "GAME_005" || CardID == "GAME_005E")
               {
                  cTheCoin = card;
                  continue;
               }

               HRBattle.TryPlayCard(card);
            }
            else
            {
               HRLog.Write(
                  String.Format("Card ({0}) is not a minion or spell or weapon and cannot be used.",
                  card.GetEntity().GetName()));
            }
         }

         // Feature: The Coin
         // https://github.com/juce-mmocrawlerbots/HREngine/issues/13
         if (cTheCoin != null)
         {
            int numResources = HRPlayer.GetLocalPlayer().GetNumAvailableResources() + 1;
            foreach (var card in hand)
            {
               if (card.GetEntity().IsMinion() || card.GetEntity().IsSpell() || (!p.HasWeapon() && card.GetEntity().IsWeapon()))
               {
                  if (card.GetEntity().GetCost() < numResources)
                  {
                     HRLog.Write(String.Format("Spawn [{0}] and then [{1}]", cTheCoin.GetEntity().GetName(), card.GetEntity().GetName()));
                     HRBattle.TryPlayCard(cTheCoin);
                     HRBattle.TryPlayCard(card);
                  }

               }
               else
               {
                  HRLog.Write(
                     String.Format("Card ({0}) is not a minion or spell or weapon and cannot be used.",
                     card.GetEntity().GetName()));
               }
            }
         }
      }

      protected virtual void TrySpawnCharges()
      {
         var p = HRPlayer.GetLocalPlayer();

         List<HRCard> hand = HRCard.GetCards(p, HRCardZone.HAND);
         foreach (var card in hand)
         {
            if (card.GetEntity().HasCharge())
               HRBattle.TryPlayCard(card);
         }
      }

      protected virtual void TryFight()
      {
         List<int> lsCheckedEntities = new List<int>();
         HRCard nextMinion = null;

         using (var imp = new HRDeadlockBypass("TryFight"))
         {
            do
            {
               nextMinion = GetMinionByPriority(nextMinion);

               if (nextMinion != null)
               {
                  var possibleAttack = GetPossibleTurnAttack(nextMinion.GetEntity().GetRemainingHP());
                  if (possibleAttack.Attack >= nextMinion.GetEntity().GetRemainingHP() &&
                     possibleAttack.Cost <= HRPlayer.GetLocalPlayer().GetNumAvailableResources() &&
                     possibleAttack.Cards.Count > 0)
                  {
                     HRLog.Write(String.Format("Fighting with {0}", nextMinion.GetEntity().GetName()));
                     PerformAttackFromPossibleTurnAttack(possibleAttack, nextMinion.GetEntity());
                  }
                  lsCheckedEntities.Add(nextMinion.GetEntity().GetEntityId());
               }

               if (imp.HasDeadlock && nextMinion != null)
               {
                  HRLog.Write(String.Format("Deadlock occured with entity {0} and ID {1}",
                     nextMinion.GetEntity().GetName(),
                     nextMinion.GetEntity().GetEntityId()));
               }
            } while (!imp.HasDeadlock && nextMinion != null);
         }

         // Try to attack his hero...?
         var e = HRPlayer.GetEnemyPlayer();
         if (!e.HasATauntMinion())
         {
            var possibleAttack = GetPossibleTurnAttack(e.GetHero().GetRemainingHP());
            if (possibleAttack.Cost <= HRPlayer.GetLocalPlayer().GetNumAvailableResources())
            {
               PerformAttackFromPossibleTurnAttack(possibleAttack, e.GetHero());
            }
         }
      }

      protected virtual void TryPossibleWin()
      {
         var e = HRPlayer.GetEnemyPlayer();
         if (e.HasATauntMinion() || !e.GetHeroCard().GetEntity().CanBeAttacked())
            return;

         var p = HRPlayer.GetLocalPlayer();

         PossibleTurnAttack possiblePower = GetPossibleTurnAttack(e.GetHero().GetRemainingHP());

         // Hunter Hero Power ATK == 0 because it has a special power attribute...
         // Fix: https://github.com/juce-mmocrawlerbots/HREngine/issues/17
         if (p.GetClass() == HRClass.HUNTER)
         {
            if (p.GetHeroPower().GetCost() <= (p.GetNumAvailableResources() - possiblePower.Cost))
            {
               possiblePower.Attack += 2; // Hunter Hero Power attacks enemy with 2 damage.
               possiblePower.Cost += p.GetHeroPower().GetCost();
               possiblePower.Cards.Add(p.GetCard()); // THIS will trigger UserHeroPower() in PerformAttackFromPossibleTurnAttack.
            }
         }

         if (possiblePower.Attack >= e.GetHero().GetRemainingHP() && possiblePower.Cost <= p.GetNumAvailableResources())
         {
            HRLog.Write(String.Format("Prepare next win, killing {0}", e.GetHero().GetName()));
            PerformAttackFromPossibleTurnAttack(possiblePower, e.GetHero());
         }
      }

      protected virtual void TryPossibleOneShots()
      {
         List<int> lsCheckedEntities = new List<int>();
         HRCard nextMinion = null;

         using (var imp = new HRDeadlockBypass("TryPossibleOneShots"))
         {
            do
            {
               nextMinion = GetMinionByPriority(nextMinion);
               if (nextMinion != null)
               {
                  var possibleAttack = GetPossibleTurnAttack(nextMinion.GetEntity().GetRemainingHP(), 1);
                  if (possibleAttack.Attack >= nextMinion.GetEntity().GetRemainingHP() &&
                     possibleAttack.Cost <= HRPlayer.GetLocalPlayer().GetNumAvailableResources() && possibleAttack.Cards.Count == 1)
                  {
                     HRLog.Write(String.Format("Perform 1 Hit to {0}", nextMinion.GetEntity().GetName()));
                     PerformAttackFromPossibleTurnAttack(possibleAttack, nextMinion.GetEntity());
                  }

                  lsCheckedEntities.Add(nextMinion.GetEntity().GetEntityId());
               }

               if (imp.HasDeadlock && nextMinion != null)
               {
                  HRLog.Write(String.Format("Deadlock occured with entity {0} and ID {1}",
                     nextMinion.GetEntity().GetName(),
                     nextMinion.GetEntity().GetEntityId()));
               }
            } while (!imp.HasDeadlock && nextMinion != null);
         }
      }

      protected void PerformAttackFromPossibleTurnAttack(PossibleTurnAttack possiblePower, HREntity entity)
      {
         if (entity == null)
            return;

         if (!entity.CanBeAttacked())
         {
            HRLog.Write(String.Format("Entity {0} cannot be attacked", entity.GetName()));
            return;
         }

         if (possiblePower.Cards == null)
            return;

         foreach (var item in possiblePower.Cards)
         {
            if (item.GetEntity().IsHero())
            {
               HRBattle.UseHeroPower(entity);
            }
            else
            {
               HRCardZone zone = item.GetEntity().GetZone();
               switch (zone)
               {
                  case HRCardZone.PLAY:
                     if (!item.GetEntity().IsWeapon())
                     {
                        HRBattle.Attack(item.GetEntity(), entity);
                     }
                     else
                     {
                        if (HRBattle.Push(HRPlayer.GetLocalPlayer().GetHeroCard()))
                        {
                           if (HRBattle.IsInTargetMode())
                           {
                              HRBattle.Target(entity);
                           }
                        }
                     }
                     break;

                  case HRCardZone.HAND:
                     if (item.GetEntity().IsMinion() && item.GetEntity().HasCharge())
                     {
                        HRBattle.Push(item);
                        HRBattle.Attack(item.GetEntity(), entity);
                     }
                     else if (item.GetEntity().IsSpell())
                     {
                        HRBattle.Push(item);
                        if (HRBattle.IsInTargetMode())
                           HRBattle.Target(entity);
                     }
                     break;

                  default:
                     break;
               }
            }
         }
      }

      protected PossibleTurnAttack GetPossibleTurnAttack(int NeededAttackPower, int MaxCards = -1)
      {
         PossibleTurnAttack result = new PossibleTurnAttack();
         result.NeededAttack = NeededAttackPower;
         result.Cards = new List<HRCard>();

         try
         {
            var p = HRPlayer.GetLocalPlayer();

            // Loop through all minions that can attack...
            List<HRCard> playerBattleField = HRCard.GetCards(HRPlayer.GetLocalPlayer(), HRCardZone.PLAY);
            foreach (var card in playerBattleField)
            {
               if (HRCardManager.CanAttackWithCard(card))
               {
                  if (MaxCards == -1)
                  {
                     result.Attack += card.GetEntity().GetATK();
                     result.Cards.Add(card);
                  }
                  else
                  {
                     if (result.Cards.Count + 1 == MaxCards)
                     {
                        if (result.Attack + card.GetEntity().GetATK() >= NeededAttackPower)
                        {
                           result.Attack += card.GetEntity().GetATK();
                           result.Cards.Add(card);
                        }
                     }
                     else
                     {
                        result.Attack += card.GetEntity().GetATK();
                        result.Cards.Add(card);
                     }
                  }

                  if (result.Attack >= result.NeededAttack || result.Cards.Count == MaxCards)
                     break;
               }
            }

            if (result.Attack < result.NeededAttack)
            {
               // Try with hero power?
               if (p.GetHeroPower().GetCost() <= p.GetNumAvailableResources())
               {
                  if (p.GetHeroPower().GetATK() > 0)
                  {
                     result.Attack += p.GetHeroPower().GetATK();
                     result.Cost += p.GetHeroPower().GetCost();
                     result.Cards.Add(p.GetHeroPower().GetCard());
                  }
               }

               // Try with weapons?
               if (p.HasWeapon() && p.GetWeaponCard().GetEntity().GetCost() <= p.GetNumAvailableResources())
               {
                  if (p.GetWeaponCard().GetEntity().GetATK() > 0 && p.GetWeaponCard().GetEntity().CanAttack())
                  {
                     result.Attack += p.GetWeaponCard().GetEntity().GetATK();
                     result.Cost += p.GetWeaponCard().GetEntity().GetCost();
                     result.Cards.Add(p.GetWeaponCard());
                  }
               }
               else if (p.GetHeroCard().GetEntity().CanAttack() && p.GetHeroCard().GetEntity().GetATK() > 0)
               {
                  result.Attack += p.GetHeroCard().GetEntity().GetATK();
                  result.Cost += p.GetHeroCard().GetEntity().GetCost();
                  result.Cards.Add(p.GetHeroCard());
               }

               // Try with remaining cards..
               if (result.Attack < result.NeededAttack)
               {
                  List<HRCard> playerHandField = HRCard.GetCards(p, HRCardZone.HAND);

                  foreach (var card in playerBattleField)
                  {
                     int leftResources = p.GetNumAvailableResources() - result.Cost;

                     if (card.GetEntity().IsSpell() && card.GetEntity().GetATK() > 0)
                     {
                        if (card.GetEntity().GetCost() <= leftResources)
                        {
                           result.Attack += card.GetEntity().GetATK();
                           result.Cost += card.GetEntity().GetCost();
                           result.Cards.Add(card);
                        }
                     }
                     else if (card.GetEntity().IsMinion() && card.GetEntity().GetATK() > 0)
                     {
                        if (card.GetEntity().HasCharge())
                        {
                           if (card.GetEntity().GetCost() <= leftResources)
                           {
                              result.Attack += card.GetEntity().GetATK();
                              result.Cost += card.GetEntity().GetCost();
                              result.Cards.Add(card);
                           }
                        }
                     }

                     if (result.Attack >= result.NeededAttack)
                        break;
                  }
               }
            }
         }
         catch (Exception)
         {
            HRLog.Write("GetPossibleTurnAttack caused an exception");
            throw;
         }

         return result;
      }

      protected virtual HRCard GetMinionByPriority(HRCard lastMinion = null)
      {
         return null;
      }
   }
}