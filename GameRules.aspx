<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="GameRules.aspx.cs" Inherits="GameRules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Styles/GameRules.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style2 {
            text-align: justify;
        }
        .auto-style3 {
            font-family: 'Times New Roman', Times, serif;
            color: crimson;
            height: 2219px;
            width: 1160px;
            position: absolute;
            top: 140px;
            left: 10px;
            text-align: justify;
        }
    </style>
    </asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div class="box" style="border-color: #00FFFF; color: #00FFFF;">
        <div class="auto-style3">
            <h2>Introduction</h2>

            <div class="auto-style2">

Blackjack is a popular American casino game, now found throughout the world. It is a banking game in which the aim of the player is to achieve a hand whose points total nearer to 21 than the banker's hand, but without exceeding 21.

In Nevada casinos the game is generally known 21 rather than Blackjack, and the holding of an ace with a 10-point card is called a "natural".

Confusingly, the name Black Jack is used in Britain for an entirely different card game which is essentially the same as Crazy Eights.

The following outline explains the basic rules of standard blackjack (21), along with the house rules most commonly featured in casinos. Players should bear in mind, though, that blackjack rules vary from casino to casino, and check for local variations before playing.

            </div>

<h2>Rules</h2>
            <div>
I overhear a lot of bad gambling advice in the casinos. Perhaps the most frequent is this one, "The object of blackjack is to get as close to 21 as possible, without going over." No! The object of blackjack is to beat the dealer. To beat the dealer the player must first not bust (go over 21) and second either outscore the dealer or have the dealer bust. Here are the full rules of the game.

            <br />
            <br />
            1.Blackjack may be played with one to eight decks of 52-card decks.
            <br />
            <br />
            2.Aces may be counted as 1 or 11 points, 2 to 9 according to pip value, and tens and face cards count as ten points.
            <br />
            <br />
            3.The value of a hand is the sum of the point values of the individual cards. Except, a "blackjack" is the highest hand, consisting of an ace and any 10-point card, and it outranks all other 21-point hands.
            <br />
            <br />
            4.After the players have bet, the dealer will give two cards to each player and two cards to himself. One of the dealer cards is dealt face up. The facedown card is called the "hole card."
            <br />
            <br />
            5.If the dealer has an ace showing, he will offer a side bet called "insurance." This side wager pays 2 to 1 if the dealer's hole card is any 10-point card. Insurance wagers are optional and may not exceed half the original wager.
            <br />
            <br />
            6.If the dealer has a ten or an ace showing (after offering insurance with an ace showing), then he will peek at his facedown card to see if he has a blackjack. If he does, then he will turn it over immediately.<br />
            <br />
            7.If the dealer does have a blackjack, then all wagers (except insurance) will lose, unless the player also has a blackjack, which will result in a push. The dealer will resolve insurance wagers at this time.
            <br />
            <br />
            8.Play begins with the player to the dealer's left. The following are the choices available to the player: 
            <br />
&nbsp;&nbsp;&nbsp; -Stand: Player stands pat with his cards.
            <br />
            <br />
&nbsp;&nbsp;&nbsp; -Hit: Player draws another card (and more if he wishes). If this card causes the player's total points to exceed 21&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (known as "breaking" or "busting") then he loses.
            <br />
            <br />
&nbsp;&nbsp;&nbsp; -Double: Player doubles his bet and gets one, and only one, more card.
            <br />
            <br />
&nbsp;&nbsp;&nbsp; -Split: If the player has a pair, or any two 10-point cards, then he may double his bet and separate his cards into two&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; individual hands. The dealer will automatically give each card a second card. Then, the player may hit, stand, or double normally. However, when splitting aces, each ace gets only one card. Sometimes doubling after splitting is not allowed. If the player gets a ten and ace after splitting, then it counts as 21 points, not a blackjack. Usually the player may keep re-splitting up to a total of four hands. Sometimes re-splitting aces is not allowed.
            <br />
            <br />
&nbsp;&nbsp;&nbsp; -Surrender: The player forfeits half his wager, keeping the other half, and does not play out his hand. This option is only available on the initial two cards, and depending on casino rules, sometimes it is not allowed at all.
            <br />
            <br />
            9.After each player has had his turn, the dealer will turn over his hole card. If the dealer has 16 or less, then he will draw another card. A special situation is when the dealer has an ace and any number of cards totaling six points (known as a "soft 17"). 
            <br />
            <br />
            10.At some tables, the dealer will also hit a soft 17.
If the dealer goes over 21 points, then any player who didn't already bust will win.
            <br />
            <br />
            11.If the dealer does not bust, then the higher point total between the player and dealer will win.<br />
            <br />
            12.Winning wagers pay even money, except a winning player blackjack usually pays 3 to 2. Some casinos have been short-paying blackjacks, which is a rule strongly in the casino's favor.
        <form runat="server">
                <div style="margin-left:450px; width: 44px;">
        <asp:Button runat="server" OnClick="ReturntoMain_Click" Text="Back"  />
        </div></form>
</div>
   </div>
        </div>
</asp:Content>