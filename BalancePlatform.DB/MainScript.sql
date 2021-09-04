
create table dbo.Battles(
  Id int not null identity(1,1) primary key
  ,Name nvarchar(256) not null
  ,Description nvarchar(max) null
  ,DateFrom datetime not null
  ,DateTill datetime not null
  ,WinnerGroupId int null
)

create table dbo.GroupButtleScore(
  Id int not null identity(1,1) primary key
  ,BattleId int not null
  ,GroupId int not null
  ,Score int not null
)

create table dbo.BattleParticipants(
  Id int not null identity(1,1) primary key
  ,AttackGroupId int not null
  ,DefenseGroupId int not null
)

create table dbo.UserToGroupRequests(
  Id int not null identity(1,1) primary key
  ,UserId int not null
  ,GroupId int not null
  ,DateCreate datetime not null
)

create table dbo.GroupToUserRequests(
  Id int not null identity(1,1) primary key
  ,GroupId int not null
  ,UserId int not null
  ,DateCreate datetime not null
)


create table dbo.ButtleRequests(
  Id int not null identity(1,1) primary key
  ,AttackGroupId int not null
  ,DefenseGroupId int not null
  ,DateCreate datetime not null
  ,RequestStatus int not null
  ,IsActive bit not null
)

create table dbo.Currency(
  UserId int not null primary key
  ,Value decimal not null
)

create table dbo.Score(
  UserId int not null primary key
  ,Score int not null
)

create table dbo.Goals(
  Id int not null identity(1,1) primary key
  ,Score int not null
  ,IsActive bit not null
  ,DateDeadline datetime not null
  ,UserId int not null
)

create table dbo.DailyPlan(
  Id int not null identity(1,1) primary key
  ,UserId int not null
  ,MinScore int not null
  ,Date datetime not null
)

create table dbo.UserBadges(
  Id int not null identity(1,1) primary key
  ,UserId int not null
  ,BadgeId int not null
)

alter table dbo.DailyPlan add constraint FK_DailyPlan_Users foreign key(UserId) references dbo.Users(Id)
alter table dbo.Goals add constraint FK_Goals_Users foreign key(UserId) references dbo.Users(Id)
alter table dbo.Score add constraint FK_Score_Users foreign key(UserId) references dbo.Users(Id)

alter table dbo.Currency add constraint FK_Currency_Users foreign key(UserId) references dbo.Users(Id)
alter table dbo.GroupToUserRequests add constraint FK_GroupToUserRequests_Users foreign key(UserId) references dbo.Users(Id)
alter table dbo.UserToGroupRequests add constraint FK_UserToGroupRequests_Users foreign key(UserId) references dbo.Users(Id)


alter table dbo.UserBadges add constraint FK_UserBadges_Users foreign key(UserId) references dbo.Users(Id)
alter table dbo.UserBadges add constraint FK_UserBadges_Badges foreign key(BadgeId) references dbo.Badges(Id)


alter table dbo.Orders add constraint FK_Orders_Users foreign key(UserId) references dbo.Users(Id)
alter table dbo.Orders add constraint FK_Orders_Products foreign key(ProductId) references dbo.Products(Id)

alter table dbo.Transactions add constraint FK_Transactions_Users foreign key(UserId) references dbo.Users(Id)

alter table dbo.Groups add constraint FK_Groups_Users foreign key(AdminId) references dbo.Users(Id)

alter table dbo.GroupToUserRequests add constraint FK_GroupToUserRequests_Users foreign key(UserId) references dbo.Users(Id)
alter table dbo.GroupToUserRequests add constraint FK_GroupToUserRequests_Groups foreign key(GroupId) references dbo.Groups(Id)


alter table dbo.UserToGroupRequests add constraint FK_UserToGroupRequests_Users foreign key(UserId) references dbo.Users(Id)
alter table dbo.UserToGroupRequests add constraint FK_UserToGroupRequests_Groups foreign key(GroupId) references dbo.Groups(Id)



alter table dbo.ButtleRequests add constraint FK_ButtleRequests_Users_AttackGroupId foreign key(AttackGroupId) references dbo.Groups(Id)
alter table dbo.ButtleRequests add constraint FK_ButtleRequests_Users_DefenseGroupId foreign key(DefenseGroupId) references dbo.Groups(Id)


alter table dbo.Battles add constraint FK_Buttles_Groups foreign key(WinnerGroupId) references dbo.Groups(Id)

alter table dbo.BattleParticipants add constraint FK_BattleParticipants_Groups_AttackGroupId foreign key(AttackGroupId) references dbo.Groups(Id)
alter table dbo.BattleParticipants add constraint FK_BattleParticipants_Groups_DefenseGroupId foreign key(DefenseGroupId) references dbo.Groups(Id)
alter table dbo.BattleParticipants add constraint FK_BattleParticipants_Battles foreign key(Id) references dbo.Battles(Id)


alter table dbo.GroupButtleScore add constraint FK_GroupButtleScore_Battles foreign key(BattleId) references dbo.Battles(Id)
alter table dbo.GroupButtleScore add constraint FK_GroupButtleScore_Group foreign key(GroupId) references dbo.Groups(Id)










