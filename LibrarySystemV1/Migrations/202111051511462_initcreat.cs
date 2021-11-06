namespace LibrarySystemV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initcreat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(nullable: false, maxLength: 50),
                        NoOfCopies = c.Int(nullable: false),
                        NoOfExistingCopies = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.Borrowers",
                c => new
                    {
                        BorrowerId = c.Int(nullable: false, identity: true),
                        BorrowerName = c.String(nullable: false, maxLength: 50),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BorrowerId);
            
            CreateTable(
                "dbo.BorrowerBooks",
                c => new
                    {
                        Borrower_BorrowerId = c.Int(nullable: false),
                        Book_BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Borrower_BorrowerId, t.Book_BookId })
                .ForeignKey("dbo.Borrowers", t => t.Borrower_BorrowerId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookId, cascadeDelete: true)
                .Index(t => t.Borrower_BorrowerId)
                .Index(t => t.Book_BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BorrowerBooks", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.BorrowerBooks", "Borrower_BorrowerId", "dbo.Borrowers");
            DropIndex("dbo.BorrowerBooks", new[] { "Book_BookId" });
            DropIndex("dbo.BorrowerBooks", new[] { "Borrower_BorrowerId" });
            DropTable("dbo.BorrowerBooks");
            DropTable("dbo.Borrowers");
            DropTable("dbo.Books");
        }
    }
}
