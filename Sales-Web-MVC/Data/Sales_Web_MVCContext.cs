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

        public DbSet<Sales_Web_MVC.Models.Department> Department { get; set; }
    }

    /*
     Iniciando a primeira migration!
        no pakcage manager console --> Add-Migration Initial
        uma pasta "Migrations" foi criada, com o primeiro script de migration ( ano, mês, dia)
        criado um snapshot também, para ter uma informação de ocmo está a base de dados no momento

     Executando a migration e criar o banco de dados no servidor do mysql?
        utilizar o comando Update-Database
            IMPORTANTE! estou pegando s valores do appsettings, então tenho que checar se está tudo ok e o mysql service está rodando
            
     */
}
