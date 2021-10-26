namespace ListBoxStyling
{
    public class UserInfo
    {
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        public UserInfo(string name, string imagePath)
        {
            this.Name = name;
            this.ImagePath = imagePath;
        }

        public static UserInfo[] Users =
        {
            new UserInfo("Arthur Alfredsen", "Images/airplane.bmp"),
            new UserInfo("Brenda Barret", "Images/astro.bmp"),
            new UserInfo("Carl Christiansen", "Images/beach.bmp"),
            new UserInfo("Delia Davis", "Images/butterfl.bmp"),
            new UserInfo("Egbert Evesham", "Images/car.bmp"),
            new UserInfo("Fenella Ferguson", "Images/cat.bmp"),
            new UserInfo("Graham Garden", "Images/chess.bmp"),
            new UserInfo("Hilary Humperdinck", "Images/dirtbike.bmp"),
            new UserInfo("Ian Ingernook", "Images/dog.bmp"),
            new UserInfo("Joan Jackson", "Images/drip.bmp"),
            new UserInfo("Kevin Kostco", "Images/duck.bmp"),
            new UserInfo("Leah Limbert", "Images/fish.bmp"),
            new UserInfo("Marvin Masterson", "Images/frog.bmp"),
            new UserInfo("Nellie Norbert", "Images/guitar.bmp"),
            new UserInfo("Ollie Ogilvy", "Images/horses.bmp"),
            new UserInfo("Priscilla Peters", "Images/kick.bmp"),
            new UserInfo("Quentin Quasires", "Images/liftoff.bmp"),
            new UserInfo("Roberta Roberts", "Images/palmtree.bmp"),
            new UserInfo("Steve Stuart", "Images/pnkflowr.bmp"),
            new UserInfo("Teri Tobeson", "Images/redflowr.bmp"),
            new UserInfo("Ulysses Uhura", "Images/skater.bmp"),
            new UserInfo("Val Vignette", "Images/snwflake.bmp"),
            new UserInfo("William Watson", "Images/drip.bmp"),
            new UserInfo("Xanthe Xardos", "Images/user.bmp"),
            new UserInfo("Ybrahim Yavin", "Images/guest.bmp"),
            new UserInfo("Zaphod Zacharzewski", "images/soccer.bmp")
        };
    }
}