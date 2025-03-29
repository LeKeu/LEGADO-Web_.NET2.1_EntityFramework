using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sales_Web_MVC.Models
{
    public class Sales_Web_MVCContext : DbContext
    {
        public Sales_Web_MVCContext (DbContextOptions<Sales_Web_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }

        // adicionei esses dois depois!
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }

    /*
     Iniciando a primeira migration!
        no pakcage manager console --> Add-Migration Initial
        uma pasta "Migrations" foi criada, com o primeiro script de migration ( ano, mês, dia)
        criado um snapshot também, para ter uma informação de ocmo está a base de dados no momento

     Executando a migration e criar o banco de dados no servidor do mysql?
        utilizar o comando Update-Database
            IMPORTANTE! estou pegando s valores do appsettings, então tenho que checar se está tudo ok e o mysql service está rodando
            
     SELLER E SALESRECORD adicionados depois!
        Add-Migration OtherEntities, e, para atualizar o banco de dados, chamamos a Update-database

     Do jeito que ele fez, o migration é apenas para criar a estrutura di banco de dados. Para popular a base, ele vai utilizar o
     SEEDING SERVICE, que vai ser um serviço independente da Migration

     Para ver que funciona mesmo, ele apagou o database. se eu rodar o update-database, a minha base de dados é criada novamente,
     só que sem nenhum registro

     CRIANDO O SEEDING SERVICE
        criei ele dentro da pasta Data
        no startup.cs, registra ele nainjeção de dependência do sistema
        no seedingservice, criei todos os objetos e "salvei" no context
        no startup, chamei o serviço no ocnfigura
     */
}
