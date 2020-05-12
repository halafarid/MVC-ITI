namespace Lab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRelationEmpDept : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "FK_DepartmentId", c => c.Int());
            CreateIndex("dbo.Employees", "FK_DepartmentId");
            AddForeignKey("dbo.Employees", "FK_DepartmentId", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "FK_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "FK_DepartmentId" });
            DropColumn("dbo.Employees", "FK_DepartmentId");
        }
    }
}
