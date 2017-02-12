namespace Image_Analysis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'855ccc46-d5d6-4fb8-bd16-ef882d85b2fa', N'Guest@gmail.com', 0, N'AArUf622vXCsdWLYmeqL/syDWMHByJi58QrZLy/C2NTwYoTsbNuenfFzodJfnc8Xug==', N'8359bc63-91c0-4e0d-b4fd-d749a0d5f868', NULL, 0, 0, NULL, 1, 0, N'Guest@gmail.com')
    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dfc773db-14c3-48e2-aa2a-90237c4f35c3', N'Admin@ImageAnalysis.com', 0, N'AGSYgpF+J0Jd0tb+/aCrSSPPOhIxnRr+kYjD0ISfZ8/zeMLONfj54mIg8nLvPipnRA==', N'5120441e-f547-47aa-bb48-bfdce1c73615', NULL, 0, 0, NULL, 1, 0, N'Admin@ImageAnalysis.com')

    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e3f05785-0301-4a8f-8f66-ff901b20f83a', N'Admin')

    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dfc773db-14c3-48e2-aa2a-90237c4f35c3', N'e3f05785-0301-4a8f-8f66-ff901b20f83a')

");
        }
        
        public override void Down()
        {
        }
    }
}
