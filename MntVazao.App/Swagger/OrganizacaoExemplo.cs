using Swashbuckle.AspNetCore.Filters;

namespace MntVazao.App.Swagger
{
    public class OrganizacaoSaidaResponseExemplo : IExamplesProvider<OrganizacaoSaida>
    {
        public OrganizacaoSaida GetExamples() => new OrganizacaoSaida
        {
            Organizacao_ID = 1,
            Organizacao_Nome = "IFES - Campus Vitória",
            Organizacao_Email = "renaneg@hotmail.com",
            Organizacao_Tel = "5527999362442",
            Organizacao_Endereco = "Av. Vitória, 1729 - Jucutuquara, Vitória - ES, 29040-780"
        };
    }

    public class OrganizacaoSaida
    {
        public int Organizacao_ID { get; set; }
        public string Organizacao_Nome { get; set; }
        public string Organizacao_Email { get; set; }
        public string Organizacao_Tel { get; set; }
        public string Organizacao_Endereco { get; set; }
    }
}
