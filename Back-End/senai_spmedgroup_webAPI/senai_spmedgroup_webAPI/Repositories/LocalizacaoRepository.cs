using MongoDB.Driver;
using senai_spmedgroup_webAPI.Domains;
using senai_spmedgroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup_webAPI.Repositories
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        private readonly IMongoCollection<Localizacao> _localizacao;

        public LocalizacaoRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("SpMedicalGroup");
            _localizacao = database.GetCollection<Localizacao>("mapas");
        }
        public void Cadastrar(Localizacao novaLocalizacao)
        {
            _localizacao.InsertOne(novaLocalizacao); 
        }

        public List<Localizacao> ListarTodas()
        {
            return _localizacao.Find(Localizacao => true).ToList();
        }
    }
}
