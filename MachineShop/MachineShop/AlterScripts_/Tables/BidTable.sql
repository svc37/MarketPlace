use [MachineShop]

alter table Bids 
add DeclineReason varchar(max) null

alter table Bids
add Declined bit null