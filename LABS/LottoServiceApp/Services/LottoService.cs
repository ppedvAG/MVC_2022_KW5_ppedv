namespace LottoServiceApp.Services
{
    public class LottoService : ILottoService
    {
        public int[] Generate(int count)
        {
            int[] zufallsZahlen = Array.CreateInstance(typeof(int), count)
                .Cast<int>().ToArray();
            
            Random random = new();
            for (int i = 0; i < zufallsZahlen.Length; i++)
            {
                int temp;

                do
                {
                    temp = random.Next(1, 49);
                } 
                while (zufallsZahlen.Contains(temp));
                
                zufallsZahlen[i] = temp;
            }
            return zufallsZahlen;
        }
    }
}
