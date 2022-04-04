namespace apiPruebaConceptoNet50.Models.Response
{
    public class Response
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public object Data { get; set; }

        public Response()
        {
            this.Codigo = 0;
        }
    }
}
