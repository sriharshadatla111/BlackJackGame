using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Game : System.Web.UI.Page
{
    private static List<Card> cardListHarsha = new List<Card>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Hit.Enabled = false;
            Deal.Enabled = true;
            Stand.Enabled = false;
        }
        else
        {
            if(Session["pcvalsum"]!=null)
            { 
            int pcvalsum = (int)Session["pcvalsum"];
            int dcvalsum = (int)Session["dcvalsum"];
            if(pcvalsum==21)
            {
                Hit.Enabled = false;
            }
            }
        }
    }

    public void GenerateInitial()
    {
        using (var context = new Entities6())
        {
            var rand = new Random();
            Card cardinstance = new Card();
            List<int> randomcards = new List<int>();
            var cardvalues = (from u in context.Cards
                              orderby u.CardInfo.PokerOrder
                              select u).ToList();
            var playercards = GenerateRandom(cardvalues, 2);
            var dealercards = GenerateRandom(cardvalues, 2);
            var playercardsaftsorting = (from v in playercards
                                         orderby v.CardInfo.Image
                                         select v).ToList();

            //cardListHarsha = playercardsaftsorting;
            var dealercardsaftersorting = (from v in dealercards
                                           orderby v.CardInfo.Image
                                           select v).ToList();

            int pcval, pcvalsum = 0;
            int dcval, dcvalsum = 0;//declared the player's card value as zero and dealer's card value as zero
            foreach (var value in playercardsaftsorting)
            {
                Image image = new Image();
                image.ImageUrl = value.CardInfo.Image;
                //value.IsAvailable = true;
                //var instance = new Card();
                //instance.IsAvailable = value.IsAvailable;
                //context.Cards.Add(instance);
                //context.SaveChanges();
                pcval = CheckCardVal(value.CardInfoId.Value);
                pcvalsum += pcval;
                image.Width = 100;
                userpanel.Controls.Add(image);
            }
            foreach (var value in dealercardsaftersorting)
            {
                Image image = new Image();
                image.ImageUrl = value.CardInfo.Image;
                image.Width = 100;

                //value.IsAvailable = true;
                //var instance = new Card();
                //instance.IsAvailable = value.IsAvailable;
                //context.Cards.Add(instance);
                //context.SaveChanges();
                dealerpanel.Controls.Add(image);
                break;
            }
            Image newimage = new Image();
            newimage.ImageUrl = "~/Images/reverseimage.png";
            newimage.Width = 100;
            dealerpanel.Controls.Add(newimage);
            foreach (var value in dealercardsaftersorting)
            {
                dcval = CheckCardVal(value.CardInfoId.Value);
                dcvalsum += dcval;
            }
            Session["pcvalsum"] = pcvalsum;
            Session["dcvalsum"] = dcvalsum;
            Session["currdcards"] = dealercardsaftersorting;
            Session["currpcards"] = playercardsaftsorting;
            Session["remainingcards"] = cardvalues;
            List<Card> remainingcards = (List<Card>)Session["remainingcards"];
            bool blackjack = CheckBJ(playercardsaftsorting);//Checking whether User Cards are Blackjack or not

            userpoints.Text = Convert.ToString(pcvalsum);

            if (blackjack == true)
            {
                YesBlackJack();
            }
        }
    }

    public void YesBlackJack()
    {
        List<Card> prevpcards = (List<Card>)Session["currpcards"];
        List<Card> prevdcards = (List<Card>)Session["currdcards"];

        foreach (var v in prevpcards)//revealing both images of user
        {
            Image image = new Image();
            image.ImageUrl = v.CardInfo.Image;
            //v.IsAvailable = true;
            //var instance = new Card();
            //instance.IsAvailable = v.IsAvailable;
            //context.Cards.Add(instance);
            //context.SaveChanges();
            image.Width = 100;
            userpanel.Controls.Add(image);
        }
        foreach (var v in prevdcards)//revealing both images of dealer
        {
            Image image = new Image();
            image.ImageUrl = v.CardInfo.Image;
            image.Width = 100;
            //v.IsAvailable = true;
            //var instance = new Card();
            //instance.IsAvailable = v.IsAvailable;
            //context.Cards.Add(instance);
            //context.SaveChanges();
            dealerpanel.Controls.Add(image);

        }
        int dcvalsum = (int)Session["dcvalsum"];
        if (dcvalsum == 21)
        {
            push();
        }
        else
        {
            Win();
            //swathi added below code:
            CheckBet(Convert.ToInt32(bettext.Text), "winBJ");
            ScoreUpdate("winBJ");
        }
    }

    public void push()
    {
        int dcvalsum = (int)Session["dcvalsum"];
        int pcvalsum = (int)Session["pcvalsum"];
        dealerpoints.Text = Convert.ToString(dcvalsum);
        userpoints.Text = Convert.ToString(pcvalsum);
        Hit.Enabled = false;
        Stand.Enabled = false;
    }
    public void Lose()
    {

        int dcvalsum = (int)Session["dcvalsum"];
        int pcvalsum = (int)Session["pcvalsum"];
        //swathi added below if condition
        //if (dcvalsum > pcvalsum)
        //{
        //    Result.Text = "You have lost the game";
        //}
    }
    public void Win()
    {

        int dcvalsum = (int)Session["dcvalsum"];
        int pcvalsum = (int)Session["pcvalsum"];
        Hit.Enabled = false;
        Stand.Enabled = false;
        //swathi added below if condition
        //if (dcvalsum < pcvalsum)
        //{
        //    Result.Text = "Congratulations!! You have won the game";
        //}

    }
    public int CheckCardValAgain(int sum, int val)
    {
        if (sum > 10 && (val == 1 || val == 14 || val == 27 || val == 40))
        {
            return 1;
        }
        else if (sum < 10 && (val == 1 || val == 14 || val == 27 || val == 40))
        {
            return 11;
        }
        else if (val % 13 >= 2 && val % 13 <= 10)
        {
            return val % 13;
        }
        //else (val % 13 == 0 || (val%13 +1) == 0 || (val%13 +2) == 0)

        else
        {
            return 10;
        }

    }
    public int CheckCardVal(int val)
    {
        if (val == 1 || val == 14 || val == 27 || val == 40)
        {
            return 11;
        }

        else if (val % 13 >= 2 && val % 13 <= 10)
        {
            return val % 13;
        }
        //else (val % 13 == 0 || (val%13 +1) == 0 || (val%13 +2) == 0)

        else
        {
            return 10;
        }

    }
    protected List<Card> GenerateRandom(List<Card> allcards, int count)
    {
        var finalcards = new List<Card>();
        var random = new Random();
        bool exist = false;
        do
        {
            var index = random.Next(0, allcards.Count);
            var randomcard = allcards[index];
            foreach (var c in finalcards)
            {
                if (c.CardInfo.CardInfoId == randomcard.CardInfo.CardInfoId)
                {
                    exist = true;
                    break;
                }
            }
            if (!exist)
            {
                finalcards.Add(randomcard);
                allcards.Remove(randomcard);
            }
        } while (finalcards.Count < count);
        return finalcards;
    }

    public void Hit_Click(object sender, EventArgs e)
    {
        Deal.Enabled = false;
        string status = "lose";
        List<Card> prevpcards = (List<Card>)Session["currpcards"];
        List<Card> prevdcards = (List<Card>)Session["currdcards"];
        List<Card> remcards = (List<Card>)Session["remainingcards"];
        int dcvalsum = (int)Session["dcvalsum"];
        int pcvalsum = (int)Session["pcvalsum"]; //sum of the player card count
        using (var context = new Entities6())
        {
            foreach (var v in prevpcards)
            {
                Image image = new Image();
                image.ImageUrl = v.CardInfo.Image;
                //v.IsAvailable = true;
                //var instance = new Card();
                //instance.IsAvailable = v.IsAvailable;
                //context.Cards.Add(instance);
                //context.SaveChanges();
                image.Width = 100;
                userpanel.Controls.Add(image);
            }
            foreach (var v in prevdcards)
            {
                Image image = new Image();
                image.ImageUrl = v.CardInfo.Image;
                image.Width =100;
                //v.IsAvailable = true;
                //var instance = new Card();
                //instance.IsAvailable = v.IsAvailable;
                //context.Cards.Add(instance);
                //context.SaveChanges();
                dealerpanel.Controls.Add(image);
                break;
            }
            Image revimage = new Image();
            revimage.ImageUrl = "~/Images/reverseimage.png";
            revimage.Width = 100;//check this one for the width of the image
            dealerpanel.Controls.Add(revimage);

            if (pcvalsum <= 21)
            {
                //swathi commented this
                //var userremcardvalues = (from u in remcards
                //                         select u).ToList();
                //swathi added the below code to read cards:
                var userremcardvalues = (from u in context.Cards
                                         where u.IsAvailable == false
                                         orderby u.CardInfo.PokerOrder
                                         select u).ToList();

                var newusercard = GenerateRandom(userremcardvalues, 1).ToList();
                foreach (var v in newusercard)
                {
                    Image newuserimage = new Image();
                    newuserimage.ImageUrl = v.CardInfo.Image;
                    newuserimage.Width = 100;
                    //v.IsAvailable = true;
                    //context.Cards.Add(v);
                    //context.SaveChanges();
                    userpanel.Controls.Add(newuserimage);
                    int pcval = CheckCardValAgain(pcvalsum, v.CardInfoId.Value);
                    pcvalsum += pcval;
                    prevpcards.Add(v);
                    Session["currpcards"] = prevpcards;
                    Session["pcvalsum"] = pcvalsum;
                    userpoints.Text = pcvalsum.ToString();
                }
            }
            if(pcvalsum>21)
            {
                Hit.Enabled = false;
                Busted();
                userpoints.Text = Convert.ToString(pcvalsum);
                dealerpoints.Text = Convert.ToString(dcvalsum);
            }
            
            Session["remainingcards"] = remcards;
            
        }
    }
    
    public bool CheckBJ(List<Card> twocards)
    {
        var cards = new List<Card>();

        int countface = 0, countace = 0;
        foreach (var v in twocards)
        {
            if (v.CardInfoId == 1 || v.CardInfoId == 14 || v.CardInfoId == 40 || v.CardInfoId == 27)
            {
                countace++;
            }
            else if ((v.CardInfoId % 13 == 0) || ((v.CardInfoId + 1) % 13 == 0 || ((v.CardInfoId + 2) % 13 == 0)))
            {
                countface++;
            }
        }
        if (countface == 1 && countace == 1)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public void Busted()
    {
        Hit.Enabled = false;
        Stand.Enabled = false;
        List<Card> prevdcards = (List<Card>)Session["currdcards"];
        int pcvalsum = (int)Session["pcvalsum"]; //sum of the player card count
        int dcvalsum = (int)Session["dcvalsum"];
        int betsum = (int)Session["betsum"];
        dealerpanel.Controls.Clear();
        foreach (var v in prevdcards)
        {
            Image image = new Image();
            image.ImageUrl = v.CardInfo.Image;
            image.Width = 100;
            dealerpanel.Controls.Add(image);
        }
        Result.Text = "Busted!! Dealer Wins";

        String temp = bettext.Text;//just for debugging, have to remove it
        Console.Write(temp);
        CheckBet(betsum, "lose");
        ScoreUpdate("lose");
        Deal.Enabled = true;
        userpoints.Text = Convert.ToString(pcvalsum);
    }

    protected void Stand_Click(object sender, EventArgs e)
    {
        List<Card> prevpcards = (List<Card>)Session["currpcards"];
        List<Card> prevdcards = (List<Card>)Session["currdcards"];
        int pcvalsum = (int)Session["pcvalsum"]; //sum of the player card count
        int dcvalsum = (int)Session["dcvalsum"];
        int bet = (int)Session["betsum"];

        using (var context = new Entities6())
        {
            foreach (var v in prevpcards)
            {
                Image image = new Image();
                image.ImageUrl = v.CardInfo.Image;
                //v.IsAvailable = true;
                //var instance = new Card();
                //instance.IsAvailable = v.IsAvailable;
                //context.Cards.Add(instance);
                //context.SaveChanges();
                image.Width = 100;
                userpanel.Controls.Add(image);
            }
            foreach (var v in prevdcards)
            {
                Image image = new Image();
                image.ImageUrl = v.CardInfo.Image;
                image.Width = 100;
                //v.IsAvailable = true;
                //var instance = new Card();
                //instance.IsAvailable = v.IsAvailable;
                //context.Cards.Add(instance);
                //context.SaveChanges();
                dealerpanel.Controls.Add(image);
            }
            if(dcvalsum>pcvalsum)
            {
                Lose();
                CheckBet(bet, "lose");
                ScoreUpdate("lose");
                dealerpoints.Text = Convert.ToString(dcvalsum);
                userpoints.Text = Convert.ToString(pcvalsum) + "Dealer is the Winner";
                Hit.Enabled = false;
                Stand.Enabled = false;
            }

            else
            { 
            do
            {
                if (dcvalsum < 17)
                {
                    var userremcardvalues = (from u in context.Cards
                                             where u.IsAvailable == false
                                             orderby u.CardInfo.PokerOrder
                                             select u).ToList();

                    var newusercard = GenerateRandom(userremcardvalues, 1).ToList();
                    foreach (var v in newusercard)
                    {
                        Image newuserimage = new Image();
                        newuserimage.ImageUrl = v.CardInfo.Image;
                        newuserimage.Width = 100;
                        //v.IsAvailable = true;
                        //context.Cards.Add(v);
                        //context.SaveChanges();
                        dealerpanel.Controls.Add(newuserimage);
                        int dcval = CheckCardValAgain(dcvalsum, v.CardInfoId.Value);
                        dcvalsum += dcval;
                        prevdcards.Add(v);
                        Session["currdcards"] = prevdcards;
                        Session["dcvalsum"] = dcvalsum;
                        Session["pcvalsum"] = pcvalsum;//swathi added code
                    }
                }
            } while (dcvalsum < 21 && dcvalsum<=pcvalsum);

            if (dcvalsum >= 17 && dcvalsum <=21)//swathi added condition for equal to 17
            {
                if ((dcvalsum < pcvalsum || dcvalsum > 21) && pcvalsum <=21)//swati added pcvalsum <=21
                {
                    Win();
                    CheckBet(bet, "win");
                    ScoreUpdate("win");
                    userpoints.Text = Convert.ToString(pcvalsum);
                    dealerpoints.Text = Convert.ToString(dcvalsum) + "You Won the Game";
                    Hit.Enabled = false;
                    Stand.Enabled = false;
                }
                else if ((dcvalsum > pcvalsum && dcvalsum <= 21 )) //swathi added dcval <=21
                {
                    Lose();
                    CheckBet(bet, "lose");
                    ScoreUpdate("lose");
                    dealerpoints.Text = Convert.ToString(dcvalsum);
                    userpoints.Text = Convert.ToString(pcvalsum) + "Dealer is the Winner";
                    Hit.Enabled = false;
                    Stand.Enabled = false;

                }
                else
                {
                    push();
                    CheckBet(bet, "push");
                    ScoreUpdate("push");
                    dealerpoints.Text = Convert.ToString(dcvalsum);
                    userpoints.Text = Convert.ToString(pcvalsum) + "You are the Winner, but one minute";
                    userpoints.Text = Convert.ToString(pcvalsum) + "Dealer is also the Winner";//swathi chnaged a misatched parameter
                    Hit.Enabled = false;
                    Stand.Enabled = false;
                }

            }
                /* swathi added this for 21 above check*/
            else if (dcvalsum > 21 && pcvalsum <=21)
            {
                CheckBet(bet, "win");
                ScoreUpdate("win");
                dealerpoints.Text = Convert.ToString(dcvalsum);
                userpoints.Text = Convert.ToString(pcvalsum) + "You are the Winner, since Dealer is bursted";
                Hit.Enabled = false;
                Stand.Enabled = false;
            }
            else if (dcvalsum > 21 && pcvalsum > 21) //recheck this again
            {
                CheckBet(bet, "push");
                ScoreUpdate("push");
                dealerpoints.Text = Convert.ToString(dcvalsum);
                userpoints.Text = Convert.ToString(pcvalsum) + "Bursted";
                userpoints.Text = Convert.ToString(pcvalsum) + "Bursted but you dont lose any";//mismatched name swathi changed
                Hit.Enabled = false;
                Stand.Enabled = false;
            }

        }
        }
        Deal.Enabled = true;
    }
    protected void Deal_Click(object sender, EventArgs e)
    {
        dealerpoints.Text = "";
        if (bettext.Text != "")
        {

            // int bet = (int)Session["userbet"];
            int bet = Convert.ToInt32(bettext.Text);
            bettext.Text = "";
            var validbet = CheckBet(bet, "start");
            var betok = ValidateBet(bet);
            Session["betsum"] = bet;
            if (validbet && betok)//swathi added betok condition
            {
                Stand.Enabled = true;
                userpoints.Text = "";
                Hit.Enabled = true;
                GenerateInitial();
                Deal.Enabled = false;
            }
            else
            {
                Result.Text = "Bet does not satisfy please recheck!";
            }
        }
        else
        {
            Result.Text = "";
            dealerpoints.Text = "";
            userpoints.Text = "";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Enter the Bet');</script>");
        }
    }
    
    public bool CheckBet(int bet, string status)
    {
        bool res = false;
        int banbal = 0;
        string accountholder = Session["username"] as string;

        using (var context = new Entities6())
        {

            var bankfund = from f1 in context.Account_Details
                           where f1.Username == accountholder
                           select f1;
            if (bankfund.Any())
            {
                foreach (var b in bankfund)
                {
                    banbal = b.Bankbalance;


                    if (status == "start")
                    {
                        if (banbal > bet)
                        {
                            b.Bankbalance = banbal - bet;
                            res = true;
                        }
                        else
                        {
                            res = false;
                        }

                    }




                    else if (status == "winBJ")
                    {
                        b.Bankbalance = banbal + bet + Convert.ToInt32((1.5 * bet));
                        res = true;
                    }
                    else if (status == "win")
                    {
                        b.Bankbalance = banbal + bet + (1 * bet);
                        res = true;
                    }
                    else if (status == "push")
                    {
                        b.Bankbalance = banbal + bet;
                        res = true;
                    }
                    else
                    {
                        //do nothing
                        res = true;
                    }
                }
            }
            context.SaveChanges();

        }
        return res;

    }
    /*Check for the bet being in limits*/
    public bool ValidateBet(int ubet)
    {
        bool resbet = false;
        int dbetmax = 0;
        int dbetmin = 0;
        using (var context = new Entities6())
        {
            var betamount = from betd in context.Admins
                            select betd;
            if (betamount.Any())
            {
                foreach (var b in betamount)
                {
                    dbetmin = b.A_minlimit;
                    dbetmax = b.A_maxlimit;

                }
            }
            else
            {
                resbet = false;
            }

            if (ubet >= dbetmin && ubet <= dbetmax)
            {
                resbet = true;
            }
            else
            {
                resbet = false;
            }

        }
        return resbet;

    }

    public void ScoreUpdate(string result)
    {
        using (var context = new Entities6())
        {
            string userhere = Session["username"] as string;
            var sc = from sc1 in context.Scores
                     where sc1.Username == userhere
                     select sc1;
            if (sc.Any())
            {
                foreach (var c in sc)
                {
                    if (c.LostCount == null)
                    {
                        c.LostCount = 0;
                    }
                    if (c.WinCount == null)
                    {
                        c.WinCount = 0;
                    }
                    if (c.BJCount == null)
                    {
                        c.BJCount = 0;
                    }

                    if (result == "win")
                    {
                        c.WinCount = c.WinCount+ 1;
                    }
                    else if (result == "winBJ")
                    {
                        c.WinCount = c.WinCount+ 1;
                        c.BJCount = c.BJCount + 1;

                    }
                    else if (result == "lose")
                    {
                        if (c.LostCount == null)
                        {
                            c.LostCount = 0;
                        }
                        c.LostCount = c.LostCount + 1;
                    }
                    else
                    {
                        c.LostCount = c.LostCount + 0;
                    }
                }
                context.SaveChanges();
            }
        }
    }
    protected void Logout_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MainPage.aspx");
    }
}

