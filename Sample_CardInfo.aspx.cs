using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SampleProgram : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string card = "";
        string suit = "";
        int count = 1;

        string final = card + " of " + suit;
        string url = card + "_of_" + suit + ".png";
        using (var context = new Entities6())
        {
            var poker = from cards in context.CardInfoes
                        select cards;
            var values = poker.FirstOrDefault();
            if (values == null)
            {
                for (int i = 1; i < 5; i++)
                {
                    if (i == 1)
                        suit = "diamonds";
                    else if (i == 2)
                        suit = "clubs";
                    else if (i == 3)
                        suit = "hearts";
                    else if (i == 4)
                        suit = "spades";
                    for (int j = 1; j < 14; j++)
                    {
                        CardInfo newcard = new CardInfo();
                        if (j == 1)
                            card = "ace_of_" + suit;
                        else if (j == 11)
                            card = "jack_of_" + suit;
                        else if (j == 12)
                            card = "queen_of_" + suit;
                        else if (j == 13)
                            card = "king_of_" + suit;
                        else
                            card = Convert.ToString(j) + "_of_" + suit;
                        newcard.CardInfoId = count;
                        newcard.PokerOrder = i;
                        newcard.Name = card;
                        newcard.Image = string.Format("~/images/{0}.png", card);
                        context.CardInfoes.Add(newcard);
                        context.SaveChanges();
                        card = "";
                        count++;
                    }

                }

            }
        }
    }
}