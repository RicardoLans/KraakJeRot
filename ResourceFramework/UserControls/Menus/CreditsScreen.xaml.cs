using System.Collections.Generic;
using System.Windows.Controls;
using GameFramework.Additional;
using ResourceFramework.UserControls.Additional;

namespace ResourceFramework.UserControls.Menus
{
	public partial class CreditsScreen : UserControl
	{
		private List<CreditsHolder> credits;

		public CreditsScreen()
		{
			InitializeComponent();
			FishMenu menu = new FishMenu(credits = new List<CreditsHolder>{
			                             		new CreditsHolder{
													Name = "Kelvin van Geene", 
													Age = "20 Jaar", 
													City = "Zwanenburg, The Netherlands", 
													ImgSmallString = "/ResourceFramework;component/Images/CreditScreen/kelvin.jpg", 
													ImgBigString ="/ResourceFramework;component/Images/CreditScreen/kelvinGroot.jpg", 
													ShortStory = @"Na de Havo afgerond te hebben met een Economie & Maatschappij pakket, Management & Organisatie en Informatica, ben ik in 2007 gestart met de Bachelor of Informatics studie op Hogeschool Inholland Haarlem.
De eerste 2 jaar deed ik veel met websites(HTML / PHP) en Adobe applicaties tot ik er toch achter kwam dat mijn passie meer bij het programmeren lag. Dit werd pas echt ontwikkeld tijdens mijn stage en sindsdien develop ik er aardig op los. 
In mijn vrije tijd probeer ik mij vooral te focussen op technieken die ik niet in mijn studie aangeboden krijg(PHP / WPF / Silverlight, LINQ, ADO.NET, Generics) om mij zo verder te ontwikkelen.",
													ProjectInput = @"Binnen dit project heb ik mij bezig gehouden met het programmeerwerk, het opzetten van een framework, bouwen van XAML controls en de Userinterface. Ook het management gedeelte heb ik voor mijn rekening genomen.",
													WebsiteName = "Curriculum Vitae",
													WebsiteUrl = "http://www.kelvinvangeene.com/cv"
												}, 
												new CreditsHolder{
													Name = "Jeroen van Warmerdam",
													Age = "24 Jaar",
													City = "Haarlem, The Netherlands", 
													ImgSmallString = "/ResourceFramework;component/Images/CreditScreen/jeroen.jpg",
													ImgBigString =  "/ResourceFramework;component/Images/CreditScreen/jeroen.jpg",
													ShortStory = @"Na de MBO opleiding Bouwkunde afgerond te hebben, ben ik overgestapt naar HBO Informatica. Tijdens de opleiding, stage en prive heb ik veel gewerkt met webprogrammeren, maar mijn grote interesse ligt eigenlijk bij software programmatuur. Met allerlei verschillende projecten (zoals dit project) probeer ik ervaring op te doen in een tal van verschillende programmeertalen en technieken.
Na de eerste Informatica stage, ben ik daar blijven werken om ervaring op te doen en geld te verdienen. Daarnaast werk ik nog als chef zaterdagploeg bij een interieursfabriek, waar ik leiding geef over 10 man.
In mijn vrije tijd werk ik graag met computers, klus ik graag bij, draai ik muziek met me drive-in-show en ga ik graag uit met vrienden.",
													ProjectInput = @"Bij het project heb ik mijzelf, net als Kelvin, voornamelijk met het programmeer werk bezig gehouden. Dit bestond uit het bouwen van het framework, opzetten van een tal van XAML controls en UI. Daarnaast hield ik als scrummaster het grote overzicht en begeleidde ik iedereen bij het project.",
												 	WebsiteName = "Persoonlijke website",
													WebsiteUrl = "http://www.jeroenvanwarmerdam.nl"
												}, 
												new CreditsHolder{
													Name = "Ricardo Lans",
													Age = "21 Jaar", 
													City = "Velsen-Noord, The Netherlands",
													ImgSmallString = "/ResourceFramework;component/Images/CreditScreen/ricardo.jpg", 
													ImgBigString ="/ResourceFramework;component/Images/CreditScreen/ricardoGroot.png",
													ShortStory = @"Ik doe een HBO ICT opleiding op INholland te Haarlem. Momenteel zit ik in mijn 4de en hopelijk ook laatste jaar. Mijn hobby's zijn voetbal en kickboxen. 
Zelf doe ik veel aan grafisch ontwerpen met Photoshop en begin nu veel met Illustrator te werken, als het kan probeer ik ook wat te programmeren.",
													ProjectInput = @"Voor het project heb ik voornamelijk alle visuele objecten gerealiseerd.
Mijn mede projectleden hebben meebeslist in de designs, als er een design beter kon werd het aangepast zodat iedereen tevreden was."
												}
											});

			Grid.SetColumn(menu, 0);
			stckGrid.Children.Add(menu);
			creditsHolder.creditHoldert.DataContext = credits[0];
		}

		public void SetCreditHolder(CreditsHolder holder)
		{
			creditsHolder.creditHoldert.DataContext = holder;
		}
	}
}