namespace DatabaseApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.applications",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        buyer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.buyers", t => t.buyer)
                .Index(t => t.buyer);
            
            CreateTable(
                "dbo.buyers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        buyers_name = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.cash",
                c => new
                    {
                        operation_id = c.Int(nullable: false, identity: true),
                        good_id = c.Int(nullable: false),
                        typ = c.String(nullable: false, maxLength: 1, unicode: false),
                        order_id = c.Int(nullable: false),
                        number_of_good = c.Decimal(nullable: false, precision: 6, scale: 3, storeType: "numeric"),
                        cost = c.Decimal(nullable: false, precision: 6, scale: 2, storeType: "numeric"),
                        act = c.String(nullable: false, maxLength: 10, unicode: false),
                        date_of_action = c.DateTime(nullable: false, storeType: "date"),
                        buyer_id = c.Int(),
                    })
                .PrimaryKey(t => t.operation_id)
                .ForeignKey("dbo.customs", t => t.order_id)
                .ForeignKey("dbo.goods", t => t.good_id)
                .ForeignKey("dbo.buyers", t => t.buyer_id)
                .Index(t => t.good_id)
                .Index(t => t.order_id)
                .Index(t => t.buyer_id);
            
            CreateTable(
                "dbo.customs",
                c => new
                    {
                        order_id = c.Int(nullable: false),
                        duty = c.Decimal(nullable: false, precision: 6, scale: 2, storeType: "numeric"),
                        diverly_date = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.order_id)
                .ForeignKey("dbo.orders", t => t.order_id)
                .Index(t => t.order_id);
            
            CreateTable(
                "dbo.orders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        good_id = c.Int(nullable: false),
                        quantyty = c.Decimal(nullable: false, precision: 6, scale: 3, storeType: "numeric"),
                        aplications_id = c.Int(),
                        manager_id = c.Int(nullable: false),
                        providers_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.goods", t => t.good_id)
                .ForeignKey("dbo.providers", t => t.providers_id)
                .ForeignKey("dbo.managers", t => t.manager_id)
                .ForeignKey("dbo.applications", t => t.aplications_id)
                .Index(t => t.good_id)
                .Index(t => t.aplications_id)
                .Index(t => t.manager_id)
                .Index(t => t.providers_id);
            
            CreateTable(
                "dbo.goods",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 30, unicode: false),
                        measure = c.String(nullable: false, maxLength: 10, unicode: false),
                        price_per_unit = c.Decimal(nullable: false, precision: 6, scale: 2, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.provider_goods",
                c => new
                    {
                        good_id = c.Int(nullable: false),
                        provider_id = c.Int(nullable: false),
                        time_of_deliverly = c.DateTime(nullable: false),
                        deliverly_cost = c.Decimal(nullable: false, precision: 6, scale: 2, storeType: "numeric"),
                    })
                .PrimaryKey(t => new { t.good_id, t.provider_id })
                .ForeignKey("dbo.providers", t => t.provider_id)
                .ForeignKey("dbo.goods", t => t.good_id)
                .Index(t => t.good_id)
                .Index(t => t.provider_id);
            
            CreateTable(
                "dbo.providers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        country_id = c.Int(nullable: false),
                        category_id = c.Int(nullable: false),
                        name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.providers_category", t => t.category_id)
                .ForeignKey("dbo.countries", t => t.country_id)
                .Index(t => t.country_id)
                .Index(t => t.category_id);
            
            CreateTable(
                "dbo.attribute_value",
                c => new
                    {
                        provider_id = c.Int(nullable: false),
                        category_id = c.Int(nullable: false),
                        attribute_id = c.Int(nullable: false),
                        val = c.String(nullable: false, maxLength: 80, unicode: false),
                    })
                .PrimaryKey(t => new { t.provider_id, t.category_id, t.attribute_id, t.val })
                .ForeignKey("dbo.category_attribute", t => new { t.category_id, t.attribute_id })
                .ForeignKey("dbo.providers", t => t.provider_id)
                .Index(t => t.provider_id)
                .Index(t => new { t.category_id, t.attribute_id });
            
            CreateTable(
                "dbo.category_attribute",
                c => new
                    {
                        category_id = c.Int(nullable: false),
                        attribute_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.category_id, t.attribute_id })
                .ForeignKey("dbo.providers_attributes", t => t.attribute_id)
                .ForeignKey("dbo.providers_category", t => t.category_id)
                .Index(t => t.category_id)
                .Index(t => t.attribute_id);
            
            CreateTable(
                "dbo.providers_attributes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.providers_category",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.countries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        country_name = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.sales",
                c => new
                    {
                        good_id = c.Int(nullable: false),
                        sales_volume = c.Int(nullable: false),
                        cost = c.Decimal(nullable: false, precision: 6, scale: 2, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.good_id)
                .ForeignKey("dbo.goods", t => t.good_id)
                .Index(t => t.good_id);
            
            CreateTable(
                "dbo.managers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        manager_name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.storage",
                c => new
                    {
                        cell = c.Int(nullable: false),
                        order_id = c.Int(),
                        good_volume = c.Decimal(precision: 6, scale: 3, storeType: "numeric"),
                        cell_volume = c.Decimal(nullable: false, precision: 6, scale: 3, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.cell)
                .ForeignKey("dbo.customs", t => t.order_id)
                .Index(t => t.order_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.orders", "aplications_id", "dbo.applications");
            DropForeignKey("dbo.cash", "buyer_id", "dbo.buyers");
            DropForeignKey("dbo.storage", "order_id", "dbo.customs");
            DropForeignKey("dbo.orders", "manager_id", "dbo.managers");
            DropForeignKey("dbo.sales", "good_id", "dbo.goods");
            DropForeignKey("dbo.provider_goods", "good_id", "dbo.goods");
            DropForeignKey("dbo.provider_goods", "provider_id", "dbo.providers");
            DropForeignKey("dbo.orders", "providers_id", "dbo.providers");
            DropForeignKey("dbo.providers", "country_id", "dbo.countries");
            DropForeignKey("dbo.attribute_value", "provider_id", "dbo.providers");
            DropForeignKey("dbo.providers", "category_id", "dbo.providers_category");
            DropForeignKey("dbo.category_attribute", "category_id", "dbo.providers_category");
            DropForeignKey("dbo.category_attribute", "attribute_id", "dbo.providers_attributes");
            DropForeignKey("dbo.attribute_value", new[] { "category_id", "attribute_id" }, "dbo.category_attribute");
            DropForeignKey("dbo.orders", "good_id", "dbo.goods");
            DropForeignKey("dbo.cash", "good_id", "dbo.goods");
            DropForeignKey("dbo.customs", "order_id", "dbo.orders");
            DropForeignKey("dbo.cash", "order_id", "dbo.customs");
            DropForeignKey("dbo.applications", "buyer", "dbo.buyers");
            DropIndex("dbo.storage", new[] { "order_id" });
            DropIndex("dbo.sales", new[] { "good_id" });
            DropIndex("dbo.category_attribute", new[] { "attribute_id" });
            DropIndex("dbo.category_attribute", new[] { "category_id" });
            DropIndex("dbo.attribute_value", new[] { "category_id", "attribute_id" });
            DropIndex("dbo.attribute_value", new[] { "provider_id" });
            DropIndex("dbo.providers", new[] { "category_id" });
            DropIndex("dbo.providers", new[] { "country_id" });
            DropIndex("dbo.provider_goods", new[] { "provider_id" });
            DropIndex("dbo.provider_goods", new[] { "good_id" });
            DropIndex("dbo.orders", new[] { "providers_id" });
            DropIndex("dbo.orders", new[] { "manager_id" });
            DropIndex("dbo.orders", new[] { "aplications_id" });
            DropIndex("dbo.orders", new[] { "good_id" });
            DropIndex("dbo.customs", new[] { "order_id" });
            DropIndex("dbo.cash", new[] { "buyer_id" });
            DropIndex("dbo.cash", new[] { "order_id" });
            DropIndex("dbo.cash", new[] { "good_id" });
            DropIndex("dbo.applications", new[] { "buyer" });
            DropTable("dbo.storage");
            DropTable("dbo.managers");
            DropTable("dbo.sales");
            DropTable("dbo.countries");
            DropTable("dbo.providers_category");
            DropTable("dbo.providers_attributes");
            DropTable("dbo.category_attribute");
            DropTable("dbo.attribute_value");
            DropTable("dbo.providers");
            DropTable("dbo.provider_goods");
            DropTable("dbo.goods");
            DropTable("dbo.orders");
            DropTable("dbo.customs");
            DropTable("dbo.cash");
            DropTable("dbo.buyers");
            DropTable("dbo.applications");
        }
    }
}
