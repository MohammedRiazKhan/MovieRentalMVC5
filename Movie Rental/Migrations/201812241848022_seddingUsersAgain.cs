namespace Movie_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seddingUsersAgain : DbMigration
    {
        public override void Up()
        {

            Sql(@"

            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2cbeffd1-50c3-437f-91ce-5d2c3786591c', N'guest@movierental.com', 0, N'ADjN9UIaKC2ig0vGRv2j/begPmUB7oA+06qQOlPE46QuoPnYxR2xDQLP2K70eahGTQ==', N'38ebea11-515d-4c5b-90b0-2982b7a82377', NULL, 0, 0, NULL, 1, 0, N'guest@movierental.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'811bf9b5-d99f-4831-9cdf-8577a141b4c2', N'admin@movierental.com', 0, N'AOLDLsTlFuA5ZzetNSwcKV/oZAkJyddaUhC8noQVgBbWd0QgLk5q/p8l0iIdXiSEtA==', N'711c3c0c-6bbb-4cac-9afc-7a9182ef3e01', NULL, 0, 0, NULL, 1, 0, N'admin@movierental.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b43a5838-617f-4297-86b9-82e512da3b8e', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'811bf9b5-d99f-4831-9cdf-8577a141b4c2', N'b43a5838-617f-4297-86b9-82e512da3b8e')


");

        }
        
        public override void Down()
        {
        }
    }
}
