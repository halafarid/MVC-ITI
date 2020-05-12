namespace Lab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editRelationEmpDept : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "FK_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "FK_DepartmentId" });
            AlterColumn("dbo.Employees", "FK_DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "FK_DepartmentId");
            AddForeignKey("dbo.Employees", "FK_DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "FK_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "FK_DepartmentId" });
            AlterColumn("dbo.Employees", "FK_DepartmentId", c => c.Int());
            CreateIndex("dbo.Employees", "FK_DepartmentId");
            AddForeignKey("dbo.Employees", "FK_DepartmentId", "dbo.Departments", "Id");
        }
    }
}
