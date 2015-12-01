namespace Ssibir.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AgreementNumber = c.String(nullable: false),
                        StatusId = c.Int(nullable: false),
                        AgreementDate = c.DateTime(),
                        DepartmentDate = c.DateTime(),
                        ArrivalDate = c.DateTime(),
                        TourId = c.Guid(nullable: false),
                        ClientId = c.Guid(nullable: false),
                        ManagerId = c.Guid(),
                        key = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tours", t => t.TourId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Managers", t => t.ManagerId)
                .Index(t => t.TourId)
                .Index(t => t.ClientId)
                .Index(t => t.ManagerId);

            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Cost = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Nights = c.Int(),
                        TypeId = c.Int(nullable: false),
                        isHot = c.Boolean(),
                        HotelId = c.Guid(),
                        OperatorId = c.Guid(),
                        DirectionId = c.Guid(),
                        key = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hotels", t => t.HotelId)
                .ForeignKey("dbo.Operators", t => t.OperatorId)
                .ForeignKey("dbo.Directions", t => t.DirectionId)
                .Index(t => t.HotelId)
                .Index(t => t.OperatorId)
                .Index(t => t.DirectionId);

            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        StarsId = c.Int(nullable: false),
                        GoogleMapLink = c.String(),
                        key = c.String(),
                        Location_Id = c.Guid(),
                        Page_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .ForeignKey("dbo.Pages", t => t.Page_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.Page_Id);

            CreateTable(
                "dbo.Operators",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        OfficialSite = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        key = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Directions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        key = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Body = c.String(),
                        MarkId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        TourId = c.Guid(nullable: false),
                        ClientId = c.Guid(nullable: false),
                        key = c.String(),
                        Page_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tours", t => t.TourId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Pages", t => t.Page_Id)
                .Index(t => t.TourId)
                .Index(t => t.ClientId)
                .Index(t => t.Page_Id);

            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        mobile = c.String(),
                        Birth = c.DateTime(),
                        Description = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        DocId = c.Guid(),
                        Role = c.Int(nullable: false),
                        key = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Docs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SRFPassport = c.Int(),
                        NrRFPassport = c.Int(),
                        SForPassport = c.Int(),
                        NrForPassport = c.Int(),
                        ExpirationDate = c.DateTime(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        ClientId = c.Guid(nullable: false),
                        key = c.String(),
                        Client_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.Client_Id);

            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Skype = c.String(),
                        Vk = c.String(),
                        Email = c.String(),
                        Description = c.String(),
                        Birth = c.DateTime(),
                        Login = c.String(),
                        Password = c.String(),
                        Specialty = c.String(),
                        JobId = c.Int(nullable: false),
                        key = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.SessionEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        UserId = c.Guid(nullable: false),
                        Login = c.String(),
                        Name = c.String(),
                        RoleId = c.Int(nullable: false),
                        key = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IsManual = c.Boolean(nullable: false),
                        Priority = c.Int(nullable: false),
                        Html = c.String(),
                        PreText = c.String(),
                        Part1 = c.String(),
                        Part2 = c.String(),
                        Part3 = c.String(),
                        CreatedDate = c.DateTime(),
                        TypeId = c.Int(nullable: false),
                        CreatedById = c.Guid(),
                        OperatorId = c.Guid(),
                        LocationId = c.Guid(),
                        DirectionId = c.Guid(),
                        TourId = c.Guid(),
                        key = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Managers", t => t.CreatedById)
                .ForeignKey("dbo.Operators", t => t.OperatorId)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .ForeignKey("dbo.Directions", t => t.DirectionId)
                .ForeignKey("dbo.Tours", t => t.TourId)
                .Index(t => t.CreatedById)
                .Index(t => t.OperatorId)
                .Index(t => t.LocationId)
                .Index(t => t.DirectionId)
                .Index(t => t.TourId);

            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        GoogleMapLink = c.String(),
                        DirectionId = c.Guid(),
                        key = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Directions", t => t.DirectionId)
                .Index(t => t.DirectionId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Locations", new[] { "DirectionId" });
            DropIndex("dbo.Pages", new[] { "TourId" });
            DropIndex("dbo.Pages", new[] { "DirectionId" });
            DropIndex("dbo.Pages", new[] { "LocationId" });
            DropIndex("dbo.Pages", new[] { "OperatorId" });
            DropIndex("dbo.Pages", new[] { "CreatedById" });
            DropIndex("dbo.Docs", new[] { "Client_Id" });
            DropIndex("dbo.Comments", new[] { "Page_Id" });
            DropIndex("dbo.Comments", new[] { "ClientId" });
            DropIndex("dbo.Comments", new[] { "TourId" });
            DropIndex("dbo.Hotels", new[] { "Page_Id" });
            DropIndex("dbo.Hotels", new[] { "Location_Id" });
            DropIndex("dbo.Tours", new[] { "DirectionId" });
            DropIndex("dbo.Tours", new[] { "OperatorId" });
            DropIndex("dbo.Tours", new[] { "HotelId" });
            DropIndex("dbo.Trips", new[] { "ManagerId" });
            DropIndex("dbo.Trips", new[] { "ClientId" });
            DropIndex("dbo.Trips", new[] { "TourId" });
            DropForeignKey("dbo.Locations", "DirectionId", "dbo.Directions");
            DropForeignKey("dbo.Pages", "TourId", "dbo.Tours");
            DropForeignKey("dbo.Pages", "DirectionId", "dbo.Directions");
            DropForeignKey("dbo.Pages", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Pages", "OperatorId", "dbo.Operators");
            DropForeignKey("dbo.Pages", "CreatedById", "dbo.Managers");
            DropForeignKey("dbo.Docs", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Comments", "Page_Id", "dbo.Pages");
            DropForeignKey("dbo.Comments", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Comments", "TourId", "dbo.Tours");
            DropForeignKey("dbo.Hotels", "Page_Id", "dbo.Pages");
            DropForeignKey("dbo.Hotels", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.Tours", "DirectionId", "dbo.Directions");
            DropForeignKey("dbo.Tours", "OperatorId", "dbo.Operators");
            DropForeignKey("dbo.Tours", "HotelId", "dbo.Hotels");
            DropForeignKey("dbo.Trips", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Trips", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Trips", "TourId", "dbo.Tours");
            DropTable("dbo.Locations");
            DropTable("dbo.Pages");
            DropTable("dbo.SessionEntities");
            DropTable("dbo.Managers");
            DropTable("dbo.Docs");
            DropTable("dbo.Clients");
            DropTable("dbo.Comments");
            DropTable("dbo.Directions");
            DropTable("dbo.Operators");
            DropTable("dbo.Hotels");
            DropTable("dbo.Tours");
            DropTable("dbo.Trips");
        }
    }
}
