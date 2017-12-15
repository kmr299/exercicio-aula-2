namespace Contatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V001 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.contato", "TESTE");
        }
        
        public override void Down()
        {
            AddColumn("dbo.contato", "TESTE", c => c.String(maxLength: 4000));
        }
    }
}
