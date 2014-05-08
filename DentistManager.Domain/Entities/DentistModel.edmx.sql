
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/08/2014 16:30:19
-- Generated from EDMX file: E:\MVC\projects\DentistSoft\DentistManager.Domain\Entities\DentistModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Dentist];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Appointments_Clinics]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Appointments] DROP CONSTRAINT [FK_Appointments_Clinics];
GO
IF OBJECT_ID(N'[dbo].[FK_Appointments_Doctors]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Appointments] DROP CONSTRAINT [FK_Appointments_Doctors];
GO
IF OBJECT_ID(N'[dbo].[FK_Appointments_Patient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Appointments] DROP CONSTRAINT [FK_Appointments_Patient];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomMaterial_Clinics]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomMaterial] DROP CONSTRAINT [FK_CustomMaterial_Clinics];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomMaterial_Doctors]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomMaterial] DROP CONSTRAINT [FK_CustomMaterial_Doctors];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_Doctors_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Doctors] DROP CONSTRAINT [FK_Doctors_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_Doctors_Clinics]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Doctors] DROP CONSTRAINT [FK_Doctors_Clinics];
GO
IF OBJECT_ID(N'[dbo].[FK_Images_Appointments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Images] DROP CONSTRAINT [FK_Images_Appointments];
GO
IF OBJECT_ID(N'[dbo].[FK_Images_ImageCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Images] DROP CONSTRAINT [FK_Images_ImageCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_Images_Patient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Images] DROP CONSTRAINT [FK_Images_Patient];
GO
IF OBJECT_ID(N'[dbo].[FK_MaterialTreatment_Material]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MaterialTreatment] DROP CONSTRAINT [FK_MaterialTreatment_Material];
GO
IF OBJECT_ID(N'[dbo].[FK_MaterialTreatment_Treatment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MaterialTreatment] DROP CONSTRAINT [FK_MaterialTreatment_Treatment];
GO
IF OBJECT_ID(N'[dbo].[FK_MedicinePrescription_Medicine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MedicinePrescription] DROP CONSTRAINT [FK_MedicinePrescription_Medicine];
GO
IF OBJECT_ID(N'[dbo].[FK_MedicinePrescription_Prescriptions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MedicinePrescription] DROP CONSTRAINT [FK_MedicinePrescription_Prescriptions];
GO
IF OBJECT_ID(N'[dbo].[FK_OpperationMaterials_Material]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OpperationMaterials] DROP CONSTRAINT [FK_OpperationMaterials_Material];
GO
IF OBJECT_ID(N'[dbo].[FK_OpperationMaterials_opperation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OpperationMaterials] DROP CONSTRAINT [FK_OpperationMaterials_opperation];
GO
IF OBJECT_ID(N'[dbo].[FK_Patient_Clinics]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Patients] DROP CONSTRAINT [FK_Patient_Clinics];
GO
IF OBJECT_ID(N'[dbo].[FK_PatientHistory_Patient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PatientHistory] DROP CONSTRAINT [FK_PatientHistory_Patient];
GO
IF OBJECT_ID(N'[dbo].[FK_Patients_Doctors]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Patients] DROP CONSTRAINT [FK_Patients_Doctors];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentReceipt_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentReceipt] DROP CONSTRAINT [FK_PaymentReceipt_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentReceipt_Clinics]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentReceipt] DROP CONSTRAINT [FK_PaymentReceipt_Clinics];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentReceipt_Doctors]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentReceipt] DROP CONSTRAINT [FK_PaymentReceipt_Doctors];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentReceipt_Patients]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentReceipt] DROP CONSTRAINT [FK_PaymentReceipt_Patients];
GO
IF OBJECT_ID(N'[dbo].[FK_Prescriptions_Appointments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Prescriptions] DROP CONSTRAINT [FK_Prescriptions_Appointments];
GO
IF OBJECT_ID(N'[dbo].[FK_Prescriptions_Doctors]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Prescriptions] DROP CONSTRAINT [FK_Prescriptions_Doctors];
GO
IF OBJECT_ID(N'[dbo].[FK_Prescriptions_Medicine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Prescriptions] DROP CONSTRAINT [FK_Prescriptions_Medicine];
GO
IF OBJECT_ID(N'[dbo].[FK_Prescriptions_Patient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Prescriptions] DROP CONSTRAINT [FK_Prescriptions_Patient];
GO
IF OBJECT_ID(N'[dbo].[FK_RecivingItems_Material]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecivingItems] DROP CONSTRAINT [FK_RecivingItems_Material];
GO
IF OBJECT_ID(N'[dbo].[FK_RecivingItems_Storages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecivingItems] DROP CONSTRAINT [FK_RecivingItems_Storages];
GO
IF OBJECT_ID(N'[dbo].[FK_RecivingItems_suppliers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecivingItems] DROP CONSTRAINT [FK_RecivingItems_suppliers];
GO
IF OBJECT_ID(N'[dbo].[FK_Secretaries_Clinics]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Secretaries] DROP CONSTRAINT [FK_Secretaries_Clinics];
GO
IF OBJECT_ID(N'[dbo].[FK_Secretary_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Secretaries] DROP CONSTRAINT [FK_Secretary_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_SessionValues_SessionsStats]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SessionValues] DROP CONSTRAINT [FK_SessionValues_SessionsStats];
GO
IF OBJECT_ID(N'[dbo].[FK_Storages_Clinics]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Storages] DROP CONSTRAINT [FK_Storages_Clinics];
GO
IF OBJECT_ID(N'[dbo].[FK_Treatment_Appointments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatment] DROP CONSTRAINT [FK_Treatment_Appointments];
GO
IF OBJECT_ID(N'[dbo].[FK_Treatment_Clinics]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatment] DROP CONSTRAINT [FK_Treatment_Clinics];
GO
IF OBJECT_ID(N'[dbo].[FK_Treatment_Doctors]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatment] DROP CONSTRAINT [FK_Treatment_Doctors];
GO
IF OBJECT_ID(N'[dbo].[FK_Treatment_opperation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatment] DROP CONSTRAINT [FK_Treatment_opperation];
GO
IF OBJECT_ID(N'[dbo].[FK_Warehouse_Material]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Warehouse] DROP CONSTRAINT [FK_Warehouse_Material];
GO
IF OBJECT_ID(N'[dbo].[FK_Warehouse_Storages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Warehouse] DROP CONSTRAINT [FK_Warehouse_Storages];
GO
IF OBJECT_ID(N'[dbo].[FK_suppcontact_ibfk_1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[suppcontact] DROP CONSTRAINT [FK_suppcontact_ibfk_1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[Appointments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Appointments];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[Clinics]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clinics];
GO
IF OBJECT_ID(N'[dbo].[CustomMaterial]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomMaterial];
GO
IF OBJECT_ID(N'[dbo].[Doctors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Doctors];
GO
IF OBJECT_ID(N'[dbo].[ImageCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImageCategory];
GO
IF OBJECT_ID(N'[dbo].[Images]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Images];
GO
IF OBJECT_ID(N'[dbo].[Material]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Material];
GO
IF OBJECT_ID(N'[dbo].[MaterialTreatment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MaterialTreatment];
GO
IF OBJECT_ID(N'[dbo].[Medicine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Medicine];
GO
IF OBJECT_ID(N'[dbo].[MedicinePrescription]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MedicinePrescription];
GO
IF OBJECT_ID(N'[dbo].[opperation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[opperation];
GO
IF OBJECT_ID(N'[dbo].[OpperationMaterials]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OpperationMaterials];
GO
IF OBJECT_ID(N'[dbo].[PatientHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PatientHistory];
GO
IF OBJECT_ID(N'[dbo].[Patients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Patients];
GO
IF OBJECT_ID(N'[dbo].[PaymentReceipt]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentReceipt];
GO
IF OBJECT_ID(N'[dbo].[Prescriptions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Prescriptions];
GO
IF OBJECT_ID(N'[dbo].[RecivingItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RecivingItems];
GO
IF OBJECT_ID(N'[dbo].[Secretaries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Secretaries];
GO
IF OBJECT_ID(N'[dbo].[SessionsStats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SessionsStats];
GO
IF OBJECT_ID(N'[dbo].[SessionValues]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SessionValues];
GO
IF OBJECT_ID(N'[dbo].[Storages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Storages];
GO
IF OBJECT_ID(N'[dbo].[suppcontact]', 'U') IS NOT NULL
    DROP TABLE [dbo].[suppcontact];
GO
IF OBJECT_ID(N'[dbo].[suppliers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[suppliers];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Treatment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Treatment];
GO
IF OBJECT_ID(N'[dbo].[Warehouse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Warehouse];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'Appointments'
CREATE TABLE [dbo].[Appointments] (
    [AppointmentID] int IDENTITY(1,1) NOT NULL,
    [DoctorID] int  NOT NULL,
    [PatientID] int  NOT NULL,
    [Reason] nvarchar(500)  NULL,
    [ClinicID] int  NOT NULL,
    [Status] nvarchar(50)  NOT NULL,
    [Start_date] datetime  NOT NULL,
    [End_date] datetime  NOT NULL,
    [Text] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL,
    [User_Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [UserId] nvarchar(128)  NOT NULL,
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [UserName] nvarchar(max)  NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [Discriminator] nvarchar(128)  NOT NULL,
    [Active] bit  NULL
);
GO

-- Creating table 'Clinics'
CREATE TABLE [dbo].[Clinics] (
    [ClinicID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Address] nvarchar(50)  NOT NULL,
    [Phone] nvarchar(50)  NULL,
    [Mobile] nvarchar(50)  NOT NULL,
    [Acitve] bit  NULL
);
GO

-- Creating table 'CustomMaterials'
CREATE TABLE [dbo].[CustomMaterials] (
    [CustomMaterialID] int IDENTITY(1,1) NOT NULL,
    [RequestDate] datetime  NOT NULL,
    [ReciveDate] datetime  NULL,
    [PatientID] int  NOT NULL,
    [Cost] decimal(18,4)  NULL,
    [DoctorID] int  NOT NULL,
    [Description] nvarchar(200)  NULL,
    [Name] nvarchar(50)  NOT NULL,
    [ClinicID] int  NULL,
    [Payed] bit  NULL
);
GO

-- Creating table 'Doctors'
CREATE TABLE [dbo].[Doctors] (
    [DoctorID] int IDENTITY(1,1) NOT NULL,
    [UserID] nvarchar(128)  NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Gender] nvarchar(50)  NOT NULL,
    [Age] int  NULL,
    [BrithDate] datetime  NULL,
    [Phone] nvarchar(50)  NULL,
    [Mobile] nvarchar(50)  NOT NULL,
    [Address] nvarchar(100)  NULL,
    [E_mail] nvarchar(100)  NULL,
    [Active] bit  NULL,
    [ClinicID] int  NOT NULL
);
GO

-- Creating table 'ImageCategories'
CREATE TABLE [dbo].[ImageCategories] (
    [ImageCategoryID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Price] decimal(18,4)  NULL
);
GO

-- Creating table 'Images'
CREATE TABLE [dbo].[Images] (
    [ImageID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Notice] nvarchar(50)  NULL,
    [appointmentID] int  NOT NULL,
    [ImageCategoryID] int  NOT NULL,
    [PatientID] int  NOT NULL,
    [FullImageURL] nvarchar(500)  NOT NULL,
    [MediumImageURL] nvarchar(500)  NOT NULL,
    [MinImageURL] nvarchar(500)  NOT NULL,
    [LocalImageURL] nvarchar(500)  NOT NULL
);
GO

-- Creating table 'Materials'
CREATE TABLE [dbo].[Materials] (
    [ItemID] int IDENTITY(1,1) NOT NULL,
    [ItemName] nvarchar(700)  NOT NULL,
    [PartNumber] nvarchar(50)  NULL,
    [CatID] int  NOT NULL,
    [ProdCompany] int  NULL,
    [ScaleType] nvarchar(30)  NOT NULL,
    [ReOrder] int  NULL,
    [Note] nvarchar(200)  NULL,
    [MaterialCost] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'MaterialTreatments'
CREATE TABLE [dbo].[MaterialTreatments] (
    [TeratmentID] int  NOT NULL,
    [MaterialID] int  NOT NULL,
    [MaterialCost] decimal(18,4)  NULL,
    [Quantity] float  NOT NULL
);
GO

-- Creating table 'Medicines'
CREATE TABLE [dbo].[Medicines] (
    [MedicineID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [SideEffectDecsription] nvarchar(300)  NULL,
    [ScaleType] nvarchar(50)  NOT NULL,
    [Dose] nvarchar(50)  NULL,
    [Concentration] nvarchar(50)  NULL
);
GO

-- Creating table 'opperations'
CREATE TABLE [dbo].[opperations] (
    [OpperationID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Color] nvarchar(50)  NULL,
    [Price] decimal(18,4)  NOT NULL
);
GO

-- Creating table 'OpperationMaterials'
CREATE TABLE [dbo].[OpperationMaterials] (
    [OpperationID] int  NOT NULL,
    [ItemID] int  NOT NULL,
    [Quantity] int  NULL
);
GO

-- Creating table 'PatientHistories'
CREATE TABLE [dbo].[PatientHistories] (
    [HistoryID] int IDENTITY(1,1) NOT NULL,
    [PatientID] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Descripation] nvarchar(500)  NULL
);
GO

-- Creating table 'Patients'
CREATE TABLE [dbo].[Patients] (
    [PatientID] int IDENTITY(1,1) NOT NULL,
    [ClinicID] int  NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Address] nvarchar(500)  NULL,
    [Phone] nvarchar(50)  NULL,
    [Mobile] nvarchar(50)  NOT NULL,
    [Age] int  NULL,
    [BrithDate] datetime  NOT NULL,
    [gender] nvarchar(50)  NOT NULL,
    [E_mail] nvarchar(50)  NULL,
    [Notice] nvarchar(50)  NULL,
    [DoctorID] int  NULL
);
GO

-- Creating table 'PaymentReceipts'
CREATE TABLE [dbo].[PaymentReceipts] (
    [ReceiptID] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Amount] decimal(18,4)  NOT NULL,
    [PatientID] int  NOT NULL,
    [UserID] nvarchar(128)  NOT NULL,
    [ClinicID] int  NOT NULL,
    [DoctorID] int  NOT NULL
);
GO

-- Creating table 'Prescriptions'
CREATE TABLE [dbo].[Prescriptions] (
    [PrescriptionID] int IDENTITY(1,1) NOT NULL,
    [Notice] nvarchar(500)  NULL,
    [MedicineID] int  NULL,
    [PatientID] int  NULL,
    [DoctorID] int  NULL,
    [Dose] float  NULL,
    [AppointmentID] int  NULL
);
GO

-- Creating table 'RecivingItems'
CREATE TABLE [dbo].[RecivingItems] (
    [ReciveID] int IDENTITY(1,1) NOT NULL,
    [ItemID] int  NOT NULL,
    [SuppID] int  NOT NULL,
    [Amount] int  NOT NULL,
    [ExpireDate] datetime  NULL,
    [ReciveDate] datetime  NOT NULL,
    [StorageID] int  NOT NULL,
    [Recived] bit  NULL,
    [ByoneCost] decimal(18,4)  NULL,
    [TotalCost] decimal(29,4)  NULL
);
GO

-- Creating table 'Secretaries'
CREATE TABLE [dbo].[Secretaries] (
    [SecretaryID] int IDENTITY(1,1) NOT NULL,
    [UserID] nvarchar(128)  NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Gender] nvarchar(50)  NOT NULL,
    [BrithDate] datetime  NOT NULL,
    [Phone] nvarchar(50)  NULL,
    [Mobile] nvarchar(50)  NOT NULL,
    [Address] nvarchar(50)  NULL,
    [E_mail] nvarchar(50)  NULL,
    [Active] bit  NULL,
    [ClinicID] int  NOT NULL
);
GO

-- Creating table 'SessionsStats'
CREATE TABLE [dbo].[SessionsStats] (
    [SessionID] int IDENTITY(1,1) NOT NULL,
    [UserID] nvarchar(128)  NULL,
    [SessionName] nvarchar(50)  NULL
);
GO

-- Creating table 'SessionValues'
CREATE TABLE [dbo].[SessionValues] (
    [ValueID] int IDENTITY(1,1) NOT NULL,
    [SessionID] int  NULL,
    [SessionValue1] nvarchar(max)  NULL,
    [PrortyName] nvarchar(50)  NULL
);
GO

-- Creating table 'Storages'
CREATE TABLE [dbo].[Storages] (
    [StorageID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Address] nvarchar(50)  NULL,
    [Phone] nvarchar(50)  NULL,
    [Mobile] nvarchar(50)  NULL,
    [ClinicID] int  NOT NULL,
    [Active] bit  NULL
);
GO

-- Creating table 'suppcontacts'
CREATE TABLE [dbo].[suppcontacts] (
    [Id] int  NOT NULL,
    [SuppId] int  NOT NULL,
    [ContactName] nvarchar(70)  NOT NULL,
    [ContactTitel] nvarchar(30)  NULL,
    [ContactDep] nvarchar(30)  NULL,
    [City] nvarchar(30)  NULL,
    [PhoneExt] nvarchar(10)  NULL,
    [Phone] nvarchar(20)  NULL,
    [Mobile] nvarchar(20)  NULL,
    [EMail] nvarchar(100)  NULL
);
GO

-- Creating table 'suppliers'
CREATE TABLE [dbo].[suppliers] (
    [SuppID] int IDENTITY(1,1) NOT NULL,
    [CompanyName] nvarchar(50)  NOT NULL,
    [Address] nvarchar(70)  NULL,
    [City] nvarchar(30)  NULL,
    [Countery] nvarchar(30)  NULL,
    [Phone] nvarchar(20)  NOT NULL,
    [Mobile] nvarchar(20)  NULL,
    [Fax] nvarchar(20)  NULL,
    [WebSite] nvarchar(70)  NULL,
    [TaxFileNo] nvarchar(50)  NULL,
    [TaxCommision] nvarchar(50)  NULL,
    [TaxRegNo] nvarchar(50)  NULL,
    [Notes] nvarchar(200)  NULL,
    [openbalance] decimal(19,2)  NULL,
    [Type] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Treatments'
CREATE TABLE [dbo].[Treatments] (
    [TeratmentID] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(500)  NULL,
    [AppointmentID] int  NOT NULL,
    [DoctorID] int  NOT NULL,
    [PatientID] int  NOT NULL,
    [OpperationID] int  NOT NULL,
    [ToothSideNumber] nvarchar(50)  NULL,
    [ToothNumber] nvarchar(50)  NULL,
    [OpperationCost] decimal(18,4)  NULL,
    [TeratmentCost] decimal(18,4)  NOT NULL,
    [ClinicID] int  NOT NULL
);
GO

-- Creating table 'Warehouses'
CREATE TABLE [dbo].[Warehouses] (
    [WarehouseID] int IDENTITY(1,1) NOT NULL,
    [StorageID] int  NOT NULL,
    [ItemID] int  NOT NULL,
    [Available] int  NOT NULL,
    [Reserved] int  NOT NULL,
    [Total] int  NULL,
    [CostPrice] decimal(18,4)  NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'MedicinePrescription'
CREATE TABLE [dbo].[MedicinePrescription] (
    [Medicines_MedicineID] int  NOT NULL,
    [Prescriptions1_PrescriptionID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [AppointmentID] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [PK_Appointments]
    PRIMARY KEY CLUSTERED ([AppointmentID] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId], [LoginProvider], [ProviderKey] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([UserId], [LoginProvider], [ProviderKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ClinicID] in table 'Clinics'
ALTER TABLE [dbo].[Clinics]
ADD CONSTRAINT [PK_Clinics]
    PRIMARY KEY CLUSTERED ([ClinicID] ASC);
GO

-- Creating primary key on [CustomMaterialID] in table 'CustomMaterials'
ALTER TABLE [dbo].[CustomMaterials]
ADD CONSTRAINT [PK_CustomMaterials]
    PRIMARY KEY CLUSTERED ([CustomMaterialID] ASC);
GO

-- Creating primary key on [DoctorID] in table 'Doctors'
ALTER TABLE [dbo].[Doctors]
ADD CONSTRAINT [PK_Doctors]
    PRIMARY KEY CLUSTERED ([DoctorID] ASC);
GO

-- Creating primary key on [ImageCategoryID] in table 'ImageCategories'
ALTER TABLE [dbo].[ImageCategories]
ADD CONSTRAINT [PK_ImageCategories]
    PRIMARY KEY CLUSTERED ([ImageCategoryID] ASC);
GO

-- Creating primary key on [ImageID] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [PK_Images]
    PRIMARY KEY CLUSTERED ([ImageID] ASC);
GO

-- Creating primary key on [ItemID] in table 'Materials'
ALTER TABLE [dbo].[Materials]
ADD CONSTRAINT [PK_Materials]
    PRIMARY KEY CLUSTERED ([ItemID] ASC);
GO

-- Creating primary key on [TeratmentID], [MaterialID] in table 'MaterialTreatments'
ALTER TABLE [dbo].[MaterialTreatments]
ADD CONSTRAINT [PK_MaterialTreatments]
    PRIMARY KEY CLUSTERED ([TeratmentID], [MaterialID] ASC);
GO

-- Creating primary key on [MedicineID] in table 'Medicines'
ALTER TABLE [dbo].[Medicines]
ADD CONSTRAINT [PK_Medicines]
    PRIMARY KEY CLUSTERED ([MedicineID] ASC);
GO

-- Creating primary key on [OpperationID] in table 'opperations'
ALTER TABLE [dbo].[opperations]
ADD CONSTRAINT [PK_opperations]
    PRIMARY KEY CLUSTERED ([OpperationID] ASC);
GO

-- Creating primary key on [OpperationID], [ItemID] in table 'OpperationMaterials'
ALTER TABLE [dbo].[OpperationMaterials]
ADD CONSTRAINT [PK_OpperationMaterials]
    PRIMARY KEY CLUSTERED ([OpperationID], [ItemID] ASC);
GO

-- Creating primary key on [HistoryID] in table 'PatientHistories'
ALTER TABLE [dbo].[PatientHistories]
ADD CONSTRAINT [PK_PatientHistories]
    PRIMARY KEY CLUSTERED ([HistoryID] ASC);
GO

-- Creating primary key on [PatientID] in table 'Patients'
ALTER TABLE [dbo].[Patients]
ADD CONSTRAINT [PK_Patients]
    PRIMARY KEY CLUSTERED ([PatientID] ASC);
GO

-- Creating primary key on [ReceiptID] in table 'PaymentReceipts'
ALTER TABLE [dbo].[PaymentReceipts]
ADD CONSTRAINT [PK_PaymentReceipts]
    PRIMARY KEY CLUSTERED ([ReceiptID] ASC);
GO

-- Creating primary key on [PrescriptionID] in table 'Prescriptions'
ALTER TABLE [dbo].[Prescriptions]
ADD CONSTRAINT [PK_Prescriptions]
    PRIMARY KEY CLUSTERED ([PrescriptionID] ASC);
GO

-- Creating primary key on [ReciveID] in table 'RecivingItems'
ALTER TABLE [dbo].[RecivingItems]
ADD CONSTRAINT [PK_RecivingItems]
    PRIMARY KEY CLUSTERED ([ReciveID] ASC);
GO

-- Creating primary key on [SecretaryID] in table 'Secretaries'
ALTER TABLE [dbo].[Secretaries]
ADD CONSTRAINT [PK_Secretaries]
    PRIMARY KEY CLUSTERED ([SecretaryID] ASC);
GO

-- Creating primary key on [SessionID] in table 'SessionsStats'
ALTER TABLE [dbo].[SessionsStats]
ADD CONSTRAINT [PK_SessionsStats]
    PRIMARY KEY CLUSTERED ([SessionID] ASC);
GO

-- Creating primary key on [ValueID] in table 'SessionValues'
ALTER TABLE [dbo].[SessionValues]
ADD CONSTRAINT [PK_SessionValues]
    PRIMARY KEY CLUSTERED ([ValueID] ASC);
GO

-- Creating primary key on [StorageID] in table 'Storages'
ALTER TABLE [dbo].[Storages]
ADD CONSTRAINT [PK_Storages]
    PRIMARY KEY CLUSTERED ([StorageID] ASC);
GO

-- Creating primary key on [Id] in table 'suppcontacts'
ALTER TABLE [dbo].[suppcontacts]
ADD CONSTRAINT [PK_suppcontacts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [SuppID] in table 'suppliers'
ALTER TABLE [dbo].[suppliers]
ADD CONSTRAINT [PK_suppliers]
    PRIMARY KEY CLUSTERED ([SuppID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [TeratmentID] in table 'Treatments'
ALTER TABLE [dbo].[Treatments]
ADD CONSTRAINT [PK_Treatments]
    PRIMARY KEY CLUSTERED ([TeratmentID] ASC);
GO

-- Creating primary key on [WarehouseID] in table 'Warehouses'
ALTER TABLE [dbo].[Warehouses]
ADD CONSTRAINT [PK_Warehouses]
    PRIMARY KEY CLUSTERED ([WarehouseID] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- Creating primary key on [Medicines_MedicineID], [Prescriptions1_PrescriptionID] in table 'MedicinePrescription'
ALTER TABLE [dbo].[MedicinePrescription]
ADD CONSTRAINT [PK_MedicinePrescription]
    PRIMARY KEY CLUSTERED ([Medicines_MedicineID], [Prescriptions1_PrescriptionID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ClinicID] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [FK_Appointments_Clinics]
    FOREIGN KEY ([ClinicID])
    REFERENCES [dbo].[Clinics]
        ([ClinicID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Appointments_Clinics'
CREATE INDEX [IX_FK_Appointments_Clinics]
ON [dbo].[Appointments]
    ([ClinicID]);
GO

-- Creating foreign key on [DoctorID] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [FK_Appointments_Doctors]
    FOREIGN KEY ([DoctorID])
    REFERENCES [dbo].[Doctors]
        ([DoctorID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Appointments_Doctors'
CREATE INDEX [IX_FK_Appointments_Doctors]
ON [dbo].[Appointments]
    ([DoctorID]);
GO

-- Creating foreign key on [PatientID] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [FK_Appointments_Patient]
    FOREIGN KEY ([PatientID])
    REFERENCES [dbo].[Patients]
        ([PatientID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Appointments_Patient'
CREATE INDEX [IX_FK_Appointments_Patient]
ON [dbo].[Appointments]
    ([PatientID]);
GO

-- Creating foreign key on [appointmentID] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [FK_Images_Appointments]
    FOREIGN KEY ([appointmentID])
    REFERENCES [dbo].[Appointments]
        ([AppointmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Images_Appointments'
CREATE INDEX [IX_FK_Images_Appointments]
ON [dbo].[Images]
    ([appointmentID]);
GO

-- Creating foreign key on [AppointmentID] in table 'Prescriptions'
ALTER TABLE [dbo].[Prescriptions]
ADD CONSTRAINT [FK_Prescriptions_Appointments]
    FOREIGN KEY ([AppointmentID])
    REFERENCES [dbo].[Appointments]
        ([AppointmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Prescriptions_Appointments'
CREATE INDEX [IX_FK_Prescriptions_Appointments]
ON [dbo].[Prescriptions]
    ([AppointmentID]);
GO

-- Creating foreign key on [AppointmentID] in table 'Treatments'
ALTER TABLE [dbo].[Treatments]
ADD CONSTRAINT [FK_Treatment_Appointments]
    FOREIGN KEY ([AppointmentID])
    REFERENCES [dbo].[Appointments]
        ([AppointmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Treatment_Appointments'
CREATE INDEX [IX_FK_Treatment_Appointments]
ON [dbo].[Treatments]
    ([AppointmentID]);
GO

-- Creating foreign key on [User_Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id]
ON [dbo].[AspNetUserClaims]
    ([User_Id]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserID] in table 'Doctors'
ALTER TABLE [dbo].[Doctors]
ADD CONSTRAINT [FK_Doctors_AspNetUsers]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Doctors_AspNetUsers'
CREATE INDEX [IX_FK_Doctors_AspNetUsers]
ON [dbo].[Doctors]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'PaymentReceipts'
ALTER TABLE [dbo].[PaymentReceipts]
ADD CONSTRAINT [FK_PaymentReceipt_AspNetUsers]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentReceipt_AspNetUsers'
CREATE INDEX [IX_FK_PaymentReceipt_AspNetUsers]
ON [dbo].[PaymentReceipts]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'Secretaries'
ALTER TABLE [dbo].[Secretaries]
ADD CONSTRAINT [FK_Secretary_AspNetUsers]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Secretary_AspNetUsers'
CREATE INDEX [IX_FK_Secretary_AspNetUsers]
ON [dbo].[Secretaries]
    ([UserID]);
GO

-- Creating foreign key on [ClinicID] in table 'CustomMaterials'
ALTER TABLE [dbo].[CustomMaterials]
ADD CONSTRAINT [FK_CustomMaterial_Clinics]
    FOREIGN KEY ([ClinicID])
    REFERENCES [dbo].[Clinics]
        ([ClinicID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomMaterial_Clinics'
CREATE INDEX [IX_FK_CustomMaterial_Clinics]
ON [dbo].[CustomMaterials]
    ([ClinicID]);
GO

-- Creating foreign key on [ClinicID] in table 'Doctors'
ALTER TABLE [dbo].[Doctors]
ADD CONSTRAINT [FK_Doctors_Clinics]
    FOREIGN KEY ([ClinicID])
    REFERENCES [dbo].[Clinics]
        ([ClinicID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Doctors_Clinics'
CREATE INDEX [IX_FK_Doctors_Clinics]
ON [dbo].[Doctors]
    ([ClinicID]);
GO

-- Creating foreign key on [ClinicID] in table 'Patients'
ALTER TABLE [dbo].[Patients]
ADD CONSTRAINT [FK_Patient_Clinics]
    FOREIGN KEY ([ClinicID])
    REFERENCES [dbo].[Clinics]
        ([ClinicID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Patient_Clinics'
CREATE INDEX [IX_FK_Patient_Clinics]
ON [dbo].[Patients]
    ([ClinicID]);
GO

-- Creating foreign key on [ClinicID] in table 'PaymentReceipts'
ALTER TABLE [dbo].[PaymentReceipts]
ADD CONSTRAINT [FK_PaymentReceipt_Clinics]
    FOREIGN KEY ([ClinicID])
    REFERENCES [dbo].[Clinics]
        ([ClinicID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentReceipt_Clinics'
CREATE INDEX [IX_FK_PaymentReceipt_Clinics]
ON [dbo].[PaymentReceipts]
    ([ClinicID]);
GO

-- Creating foreign key on [ClinicID] in table 'Secretaries'
ALTER TABLE [dbo].[Secretaries]
ADD CONSTRAINT [FK_Secretaries_Clinics]
    FOREIGN KEY ([ClinicID])
    REFERENCES [dbo].[Clinics]
        ([ClinicID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Secretaries_Clinics'
CREATE INDEX [IX_FK_Secretaries_Clinics]
ON [dbo].[Secretaries]
    ([ClinicID]);
GO

-- Creating foreign key on [ClinicID] in table 'Storages'
ALTER TABLE [dbo].[Storages]
ADD CONSTRAINT [FK_Storages_Clinics]
    FOREIGN KEY ([ClinicID])
    REFERENCES [dbo].[Clinics]
        ([ClinicID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Storages_Clinics'
CREATE INDEX [IX_FK_Storages_Clinics]
ON [dbo].[Storages]
    ([ClinicID]);
GO

-- Creating foreign key on [ClinicID] in table 'Treatments'
ALTER TABLE [dbo].[Treatments]
ADD CONSTRAINT [FK_Treatment_Clinics]
    FOREIGN KEY ([ClinicID])
    REFERENCES [dbo].[Clinics]
        ([ClinicID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Treatment_Clinics'
CREATE INDEX [IX_FK_Treatment_Clinics]
ON [dbo].[Treatments]
    ([ClinicID]);
GO

-- Creating foreign key on [DoctorID] in table 'CustomMaterials'
ALTER TABLE [dbo].[CustomMaterials]
ADD CONSTRAINT [FK_CustomMaterial_Doctors]
    FOREIGN KEY ([DoctorID])
    REFERENCES [dbo].[Doctors]
        ([DoctorID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomMaterial_Doctors'
CREATE INDEX [IX_FK_CustomMaterial_Doctors]
ON [dbo].[CustomMaterials]
    ([DoctorID]);
GO

-- Creating foreign key on [DoctorID] in table 'Patients'
ALTER TABLE [dbo].[Patients]
ADD CONSTRAINT [FK_Patients_Doctors]
    FOREIGN KEY ([DoctorID])
    REFERENCES [dbo].[Doctors]
        ([DoctorID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Patients_Doctors'
CREATE INDEX [IX_FK_Patients_Doctors]
ON [dbo].[Patients]
    ([DoctorID]);
GO

-- Creating foreign key on [DoctorID] in table 'PaymentReceipts'
ALTER TABLE [dbo].[PaymentReceipts]
ADD CONSTRAINT [FK_PaymentReceipt_Doctors]
    FOREIGN KEY ([DoctorID])
    REFERENCES [dbo].[Doctors]
        ([DoctorID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentReceipt_Doctors'
CREATE INDEX [IX_FK_PaymentReceipt_Doctors]
ON [dbo].[PaymentReceipts]
    ([DoctorID]);
GO

-- Creating foreign key on [DoctorID] in table 'Prescriptions'
ALTER TABLE [dbo].[Prescriptions]
ADD CONSTRAINT [FK_Prescriptions_Doctors]
    FOREIGN KEY ([DoctorID])
    REFERENCES [dbo].[Doctors]
        ([DoctorID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Prescriptions_Doctors'
CREATE INDEX [IX_FK_Prescriptions_Doctors]
ON [dbo].[Prescriptions]
    ([DoctorID]);
GO

-- Creating foreign key on [DoctorID] in table 'Treatments'
ALTER TABLE [dbo].[Treatments]
ADD CONSTRAINT [FK_Treatment_Doctors]
    FOREIGN KEY ([DoctorID])
    REFERENCES [dbo].[Doctors]
        ([DoctorID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Treatment_Doctors'
CREATE INDEX [IX_FK_Treatment_Doctors]
ON [dbo].[Treatments]
    ([DoctorID]);
GO

-- Creating foreign key on [ImageCategoryID] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [FK_Images_ImageCategory]
    FOREIGN KEY ([ImageCategoryID])
    REFERENCES [dbo].[ImageCategories]
        ([ImageCategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Images_ImageCategory'
CREATE INDEX [IX_FK_Images_ImageCategory]
ON [dbo].[Images]
    ([ImageCategoryID]);
GO

-- Creating foreign key on [PatientID] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [FK_Images_Patient]
    FOREIGN KEY ([PatientID])
    REFERENCES [dbo].[Patients]
        ([PatientID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Images_Patient'
CREATE INDEX [IX_FK_Images_Patient]
ON [dbo].[Images]
    ([PatientID]);
GO

-- Creating foreign key on [MaterialID] in table 'MaterialTreatments'
ALTER TABLE [dbo].[MaterialTreatments]
ADD CONSTRAINT [FK_MaterialTreatment_Material]
    FOREIGN KEY ([MaterialID])
    REFERENCES [dbo].[Materials]
        ([ItemID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MaterialTreatment_Material'
CREATE INDEX [IX_FK_MaterialTreatment_Material]
ON [dbo].[MaterialTreatments]
    ([MaterialID]);
GO

-- Creating foreign key on [ItemID] in table 'OpperationMaterials'
ALTER TABLE [dbo].[OpperationMaterials]
ADD CONSTRAINT [FK_OpperationMaterials_Material]
    FOREIGN KEY ([ItemID])
    REFERENCES [dbo].[Materials]
        ([ItemID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OpperationMaterials_Material'
CREATE INDEX [IX_FK_OpperationMaterials_Material]
ON [dbo].[OpperationMaterials]
    ([ItemID]);
GO

-- Creating foreign key on [ItemID] in table 'RecivingItems'
ALTER TABLE [dbo].[RecivingItems]
ADD CONSTRAINT [FK_RecivingItems_Material]
    FOREIGN KEY ([ItemID])
    REFERENCES [dbo].[Materials]
        ([ItemID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RecivingItems_Material'
CREATE INDEX [IX_FK_RecivingItems_Material]
ON [dbo].[RecivingItems]
    ([ItemID]);
GO

-- Creating foreign key on [ItemID] in table 'Warehouses'
ALTER TABLE [dbo].[Warehouses]
ADD CONSTRAINT [FK_Warehouse_Material]
    FOREIGN KEY ([ItemID])
    REFERENCES [dbo].[Materials]
        ([ItemID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Warehouse_Material'
CREATE INDEX [IX_FK_Warehouse_Material]
ON [dbo].[Warehouses]
    ([ItemID]);
GO

-- Creating foreign key on [TeratmentID] in table 'MaterialTreatments'
ALTER TABLE [dbo].[MaterialTreatments]
ADD CONSTRAINT [FK_MaterialTreatment_Treatment]
    FOREIGN KEY ([TeratmentID])
    REFERENCES [dbo].[Treatments]
        ([TeratmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MedicineID] in table 'Prescriptions'
ALTER TABLE [dbo].[Prescriptions]
ADD CONSTRAINT [FK_Prescriptions_Medicine]
    FOREIGN KEY ([MedicineID])
    REFERENCES [dbo].[Medicines]
        ([MedicineID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Prescriptions_Medicine'
CREATE INDEX [IX_FK_Prescriptions_Medicine]
ON [dbo].[Prescriptions]
    ([MedicineID]);
GO

-- Creating foreign key on [OpperationID] in table 'OpperationMaterials'
ALTER TABLE [dbo].[OpperationMaterials]
ADD CONSTRAINT [FK_OpperationMaterials_opperation]
    FOREIGN KEY ([OpperationID])
    REFERENCES [dbo].[opperations]
        ([OpperationID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [OpperationID] in table 'Treatments'
ALTER TABLE [dbo].[Treatments]
ADD CONSTRAINT [FK_Treatment_opperation]
    FOREIGN KEY ([OpperationID])
    REFERENCES [dbo].[opperations]
        ([OpperationID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Treatment_opperation'
CREATE INDEX [IX_FK_Treatment_opperation]
ON [dbo].[Treatments]
    ([OpperationID]);
GO

-- Creating foreign key on [PatientID] in table 'PatientHistories'
ALTER TABLE [dbo].[PatientHistories]
ADD CONSTRAINT [FK_PatientHistory_Patient]
    FOREIGN KEY ([PatientID])
    REFERENCES [dbo].[Patients]
        ([PatientID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PatientHistory_Patient'
CREATE INDEX [IX_FK_PatientHistory_Patient]
ON [dbo].[PatientHistories]
    ([PatientID]);
GO

-- Creating foreign key on [PatientID] in table 'PaymentReceipts'
ALTER TABLE [dbo].[PaymentReceipts]
ADD CONSTRAINT [FK_PaymentReceipt_Patients]
    FOREIGN KEY ([PatientID])
    REFERENCES [dbo].[Patients]
        ([PatientID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentReceipt_Patients'
CREATE INDEX [IX_FK_PaymentReceipt_Patients]
ON [dbo].[PaymentReceipts]
    ([PatientID]);
GO

-- Creating foreign key on [PatientID] in table 'Prescriptions'
ALTER TABLE [dbo].[Prescriptions]
ADD CONSTRAINT [FK_Prescriptions_Patient]
    FOREIGN KEY ([PatientID])
    REFERENCES [dbo].[Patients]
        ([PatientID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Prescriptions_Patient'
CREATE INDEX [IX_FK_Prescriptions_Patient]
ON [dbo].[Prescriptions]
    ([PatientID]);
GO

-- Creating foreign key on [StorageID] in table 'RecivingItems'
ALTER TABLE [dbo].[RecivingItems]
ADD CONSTRAINT [FK_RecivingItems_Storages]
    FOREIGN KEY ([StorageID])
    REFERENCES [dbo].[Storages]
        ([StorageID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RecivingItems_Storages'
CREATE INDEX [IX_FK_RecivingItems_Storages]
ON [dbo].[RecivingItems]
    ([StorageID]);
GO

-- Creating foreign key on [SuppID] in table 'RecivingItems'
ALTER TABLE [dbo].[RecivingItems]
ADD CONSTRAINT [FK_RecivingItems_suppliers]
    FOREIGN KEY ([SuppID])
    REFERENCES [dbo].[suppliers]
        ([SuppID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RecivingItems_suppliers'
CREATE INDEX [IX_FK_RecivingItems_suppliers]
ON [dbo].[RecivingItems]
    ([SuppID]);
GO

-- Creating foreign key on [SessionID] in table 'SessionValues'
ALTER TABLE [dbo].[SessionValues]
ADD CONSTRAINT [FK_SessionValues_SessionsStats]
    FOREIGN KEY ([SessionID])
    REFERENCES [dbo].[SessionsStats]
        ([SessionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SessionValues_SessionsStats'
CREATE INDEX [IX_FK_SessionValues_SessionsStats]
ON [dbo].[SessionValues]
    ([SessionID]);
GO

-- Creating foreign key on [StorageID] in table 'Warehouses'
ALTER TABLE [dbo].[Warehouses]
ADD CONSTRAINT [FK_Warehouse_Storages]
    FOREIGN KEY ([StorageID])
    REFERENCES [dbo].[Storages]
        ([StorageID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Warehouse_Storages'
CREATE INDEX [IX_FK_Warehouse_Storages]
ON [dbo].[Warehouses]
    ([StorageID]);
GO

-- Creating foreign key on [SuppId] in table 'suppcontacts'
ALTER TABLE [dbo].[suppcontacts]
ADD CONSTRAINT [FK_suppcontact_ibfk_1]
    FOREIGN KEY ([SuppId])
    REFERENCES [dbo].[suppliers]
        ([SuppID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_suppcontact_ibfk_1'
CREATE INDEX [IX_FK_suppcontact_ibfk_1]
ON [dbo].[suppcontacts]
    ([SuppId]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [Medicines_MedicineID] in table 'MedicinePrescription'
ALTER TABLE [dbo].[MedicinePrescription]
ADD CONSTRAINT [FK_MedicinePrescription_Medicine]
    FOREIGN KEY ([Medicines_MedicineID])
    REFERENCES [dbo].[Medicines]
        ([MedicineID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Prescriptions1_PrescriptionID] in table 'MedicinePrescription'
ALTER TABLE [dbo].[MedicinePrescription]
ADD CONSTRAINT [FK_MedicinePrescription_Prescriptions]
    FOREIGN KEY ([Prescriptions1_PrescriptionID])
    REFERENCES [dbo].[Prescriptions]
        ([PrescriptionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MedicinePrescription_Prescriptions'
CREATE INDEX [IX_FK_MedicinePrescription_Prescriptions]
ON [dbo].[MedicinePrescription]
    ([Prescriptions1_PrescriptionID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------