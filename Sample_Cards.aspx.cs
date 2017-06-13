using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sample_Cards : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        using(var context = new Entities6())
        {
            Card instance = new Card();
            for(int i=0;i<5;i++)
            {
                
                for(int j=0;j<52;j++)
                {
                    instance.CardInfoId = j + 1;
                    instance.Deck = i + 1;
                    instance.IsAvailable = false;
                    context.Cards.Add(instance);
                    context.SaveChanges();    
                }
            }
            
        }
    }
}