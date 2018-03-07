namespace Legends_lib
{
    public class Movimento
    {

        public int DimXCasaini { get; set; }
        public int DimYCasaini { get; set; }
        public int DimXCasafim { get; set; }
        public int DimYCasafim { get; set; }

        public Movimento (int xi, int yi, int xf, int yf)
        {
            this.DimXCasaini = xi;
            this.DimYCasaini = yi;
            this.DimXCasafim = xf;
            this.DimYCasafim = yf;
        }
        
    }
}