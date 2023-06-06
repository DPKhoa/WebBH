﻿namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Product", "OriginalPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.tb_Product", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.tb_Product", "PriceSale", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Product", "PriceSale", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.tb_Product", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.tb_Product", "OriginalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
