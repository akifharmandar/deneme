namespace WFAPersonelTakibi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<WFAPersonelTakibi.Models.Context.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WFAPersonelTakibi.Models.Context.MyContext context)
        {
            //string[] departmanlar = { "yazılım", "muhasebe", "lojistik" };

            //for (int i = 0; i < departmanlar.Length; i++)
            //{
            //    Department department = new Department();
            //    department.Name = departmanlar[i];
            //    context.Departments.Add(department);
            //    context.SaveChanges();
            //}
        }
    }
}
