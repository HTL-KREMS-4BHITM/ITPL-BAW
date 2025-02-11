create table `GROUPS`
(
    GROUP_ID      int auto_increment
        primary key,
    NAME          varchar(100)                         not null,
    FROM_DATE     date                                 not null,
    TO_DATE       date                                 not null,
    DESCRIPTION   text                                 not null,
    ROUTEDATA     json                                 null,
    CREATED_AT    timestamp  default CURRENT_TIMESTAMP null,
    IS_PUBLIC     tinyint(1) default 1                 null,
    FEDERAL_STATE varchar(45)                          null,
    START_TIME    time                                 null,
    constraint GROUP_ID_UNIQUE
        unique (GROUP_ID)
);

create table MOTORBIKES
(
    MOTORBIKE_ID       int auto_increment
        primary key,
    MODEL              varchar(100)  not null,
    PS                 int           not null,
    MANUFACTURER       varchar(100)  not null,
    CURRENTLEASINGRATE decimal(6, 2) not null,
    WEIGHT             int           not null,
    SEATHEIGHT         int           not null,
    KILOMETER          decimal       not null,
    FEDERAL_STATE      varchar(45)   not null,
    ADDRESS            varchar(200)  not null,
    constraint BIKE_ID_UNIQUE
        unique (MOTORBIKE_ID)
);

create table USERS
(
    USER_ID    int auto_increment
        primary key,
    AGE        int          not null,
    USERNAME   varchar(45)  not null,
    PICADDRESS varchar(15)  null,
    PASSWORD   varchar(500) not null,
    constraint USERNAME_UNIQUE
        unique (USERNAME),
    constraint USER_ID_UNIQUE
        unique (USER_ID)
);

create table FAVORITES_JT
(
    USER_ID      int not null,
    MOTORBIKE_ID int not null,
    primary key (USER_ID, MOTORBIKE_ID),
    constraint favorites_jt_ibfk_1
        foreign key (USER_ID) references USERS (USER_ID),
    constraint fk_USERS_has_BIKESJT_BIKES2
        foreign key (MOTORBIKE_ID) references MOTORBIKES (MOTORBIKE_ID)
);

create index fk_USERS_has_BIKESJT_BIKES2_idx
    on FAVORITES_JT (MOTORBIKE_ID);

create index fk_USERS_has_BIKESJT_USERS1_idx
    on FAVORITES_JT (USER_ID);

create table GROUPMEMBERS_JT
(
    USER_ID  int not null,
    GROUP_ID int not null,
    primary key (USER_ID, GROUP_ID),
    constraint groupmembers_jt_ibfk_1
        foreign key (USER_ID) references USERS (USER_ID),
    constraint groupmembers_jt_ibfk_2
        foreign key (GROUP_ID) references `GROUPS` (GROUP_ID)
);

create index GROUP_ID
    on GROUPMEMBERS_JT (GROUP_ID);

create table LEASING_CONTRACTS_JT
(
    USER_ID       int                                      not null,
    MOTORBIKE_ID  int                                      not null,
    FROM_DATE     date                                     not null,
    TO_DATE       date                                     not null,
    COST          decimal(8, 2)                            not null,
    PRICE_PER_DAY decimal(8, 2)                            null,
    INSURANCE     varchar(60) default 'Keine Versicherung' null,
    primary key (USER_ID, MOTORBIKE_ID, FROM_DATE),
    constraint fk_USERS_has_BIKESJT_BIKES1
        foreign key (MOTORBIKE_ID) references MOTORBIKES (MOTORBIKE_ID),
    constraint leasing_contracts_jt_ibfk_1
        foreign key (USER_ID) references USERS (USER_ID)
);

create index fk_USERS_has_BIKESJT_BIKES1_idx
    on LEASING_CONTRACTS_JT (MOTORBIKE_ID);

create index fk_USERS_has_BIKESJT_USERS_idx
    on LEASING_CONTRACTS_JT (USER_ID);

create table WAYPOINTS
(
    WAYPOINTID int auto_increment
        primary key,
    ADDRESS    varchar(200) null,
    SEQUENCE   int          null,
    ROUTE_ID   int          null,
    constraint waypoints_ibfk_1
        foreign key (ROUTE_ID) references `GROUPS` (GROUP_ID)
);

create index ROUTEID
    on WAYPOINTS (ROUTE_ID);

