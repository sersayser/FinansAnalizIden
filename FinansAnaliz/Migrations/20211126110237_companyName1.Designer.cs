// <auto-generated />
using System;
using FinansAnaliz.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinansAnaliz.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211126110237_companyName1")]
    partial class companyName1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinansAnaliz.Models.AnalizModel.RasyoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AktifKarMarji")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("AktifToplamiDevirHizi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("AktiflerBuyumeOrani")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("AlacakDevirHizi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("AlacakTahsilSuresi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("AlacaklarinOrtalamaTahsilSuresi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BorcOdemeSuresi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BorcYapisiOrani")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BorclanmaKatsayisi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BrutFinansalBorc")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BrutFinansalBorc_FAVOK")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BrutKarMarji")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CariOran")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DevamliSermaye")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DevamliSermayeBuyumeOrani")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DevamliSermayeDevirHizi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DevamliSermayeKarMarji")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Donem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DonenVarliklarDevirHizi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DurVar_DevSerOr")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DurVar_OzSerOr")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("EsasFaaliyetKarliligi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("EtkinlikSuresi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FAVOK_EBITDA")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FaaliyetKarliligi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FaizveVergiOncesiKar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FaizveVergiOncesiKarMarji")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FinBorc_AktOr")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FinDurVar_DevSerOr")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FinDurVar_DurVarOr")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FinansalKaldirac")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("HisseBasiDefterDegeri")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("InterestCoverageRatio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("KisVadBorc_AktOr")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("KisaVadeliYabanciKaynaklar_Ozkaynaklar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LikAkt_AktOr")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LikiditeOrani")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LikitHizliAktifler")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MadDurVar_DevSerOr")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MadDuranVar_OzSerOr")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MaddiDuranVarliklarDevirHizi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NakitCevirmeSuresi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NakitOrani")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetFaaliyetKari_NetFaaliyetKari")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetFinansalBorc_FAVÖK")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetFinansalBorc_NFB")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetIslSer_AO")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetIsletmeSermayesiBuyumeOrani")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetIsletmeSermayesiDevirHizi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetKarBuyumeOrani")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetKarMarji")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetKarMarji_EBITDAmarji")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetSatislarBuyumeOrani")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetSatislar_NetSatislar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetYabanciParaPozisyonu")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetişletmeSermayesi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OzKaynaklar_AktiflerToplami")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OzSerKarMar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OzSermayeBuyumeOrani")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OzSermayeCarpani")
                        .HasColumnType("int");

                    b.Property<decimal>("OzSermayeDevirHizi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Ozkaynak_Ozkaynak")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SatislarınIcerisindekiIhracatPayi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Ser_OzSerOr")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SermayeDevirHizi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("StokDevirHizi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("StokDevirSuresi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("StoklarinOrtalamaTuketilmeSuresi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TaahhutFaaliyetlerindenGeciciKarZarar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TicariBorclarDevirHizi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TicariBorclariOdemeSuresi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ToplamVarliklar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UzVadBor_AktOr")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UzvadBorc_DevSerOr")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VergiDonemKariOrani")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Vergi_VOKMarji")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("RasyoModels");
                });

            modelBuilder.Entity("FinansAnaliz.Models.AnalizModel.TekliVeriModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Altman_Z_Hizmet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Altman_Z_Uretim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dupond_Analizi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EtkinlikCevirmeSuresi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirmaSkoru")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NakitCevirmeSuresi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NetIsletmeSermayesi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TekliVeriModels");
                });

            modelBuilder.Entity("FinansAnaliz.Models.AnalizModel.YapisalAnalizModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Donem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DonemNetKarı_Zarari")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DonenVarliklar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DuranVarliklar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("GecmisYillarZararlari")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("GecmisYıllarKarlar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("KarYedekleri")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("KisaVadeliYabanciKaynaklar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OdenmisSermaye")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OzKaynaklar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SermayeYedekleri")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UzunVadeliYabanciKaynaklar")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("YapisalAnalizModels");
                });

            modelBuilder.Entity("FinansAnaliz.Models.Banka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankaAdi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bankalar");
                });

            modelBuilder.Entity("FinansAnaliz.Models.EntryDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateEntry")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("EntryDates");
                });

            modelBuilder.Entity("FinansAnaliz.Models.Identity.Help", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsSolved")
                        .HasColumnType("bit");

                    b.Property<string>("Problem")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ProblemDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SolvingDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Helps");
                });

            modelBuilder.Entity("FinansAnaliz.Models.MizanGonderim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BaslangicTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BitisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GonderimTarihi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MizanGonderims");
                });

            modelBuilder.Entity("FinansAnaliz.Models.Teminat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Banka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BitisTarihi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAlinanTeminat")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEkTeminat")
                        .HasColumnType("bit");

                    b.Property<string>("MainCompanyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeminatNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tutar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teminats");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FinansAnaliz.Models.Identity.AppUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsClient")
                        .HasColumnType("bit");

                    b.Property<int>("MainCompanyCode")
                        .HasColumnType("int");

                    b.Property<string>("NameOfUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("AppUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
