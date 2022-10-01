using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinansAnaliz.Migrations
{
    public partial class addTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntryDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEntry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryDates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MizanGonderims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GonderimTarihi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MizanGonderims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RasyoModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Donem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CariOran = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LikiditeOrani = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NakitOrani = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetIslSer_AO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LikAkt_AktOr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BrutFinansalBorc_FAVOK = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetFinansalBorc_FAVÖK = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KisaVadeliYabanciKaynaklar_Ozkaynaklar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OzKaynaklar_AktiflerToplami = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InterestCoverageRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinansalKaldirac = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BorclanmaKatsayisi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OzSermayeCarpani = table.Column<int>(type: "int", nullable: false),
                    KisVadBorc_AktOr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BorcYapisiOrani = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UzVadBor_AktOr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UzvadBorc_DevSerOr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinBorc_AktOr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ser_OzSerOr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MadDuranVar_OzSerOr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DurVar_DevSerOr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MadDurVar_DevSerOr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DurVar_OzSerOr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinDurVar_DurVarOr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinDurVar_DevSerOr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AlacakTahsilSuresi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BorcOdemeSuresi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StokDevirSuresi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AlacakDevirHizi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AlacaklarinOrtalamaTahsilSuresi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StokDevirHizi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StoklarinOrtalamaTuketilmeSuresi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EtkinlikSuresi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TicariBorclarDevirHizi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TicariBorclariOdemeSuresi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NakitCevirmeSuresi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetIsletmeSermayesiDevirHizi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DonenVarliklarDevirHizi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaddiDuranVarliklarDevirHizi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AktifToplamiDevirHizi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OzSermayeDevirHizi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DevamliSermayeDevirHizi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SermayeDevirHizi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BrutKarMarji = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetKarMarji_EBITDAmarji = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetKarMarji = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EsasFaaliyetKarliligi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FaaliyetKarliligi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FaizveVergiOncesiKarMarji = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Vergi_VOKMarji = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VergiDonemKariOrani = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OzSerKarMar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DevamliSermayeKarMarji = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AktifKarMarji = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DevamliSermayeBuyumeOrani = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetKarBuyumeOrani = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetSatislarBuyumeOrani = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetIsletmeSermayesiBuyumeOrani = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AktiflerBuyumeOrani = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OzSermayeBuyumeOrani = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetYabanciParaPozisyonu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SatislarınIcerisindekiIhracatPayi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetişletmeSermayesi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LikitHizliAktifler = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetFinansalBorc_NFB = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BrutFinansalBorc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FAVOK_EBITDA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToplamVarliklar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ozkaynak_Ozkaynak = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetSatislar_NetSatislar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetFaaliyetKari_NetFaaliyetKari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DevamliSermaye = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FaizveVergiOncesiKar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HisseBasiDefterDegeri = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaahhutFaaliyetlerindenGeciciKarZarar = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RasyoModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TekliVeriModels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaSkoru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Altman_Z_Uretim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Altman_Z_Hizmet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dupond_Analizi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EtkinlikCevirmeSuresi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetIsletmeSermayesi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NakitCevirmeSuresi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TekliVeriModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teminats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BayiId = table.Column<int>(type: "int", nullable: false),
                    Banka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeminatNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BitisTarihi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Miktar = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teminats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YapisalAnalizModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Donem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonenVarliklar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DuranVarliklar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KisaVadeliYabanciKaynaklar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UzunVadeliYabanciKaynaklar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OzKaynaklar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OdenmisSermaye = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SermayeYedekleri = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KarYedekleri = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GecmisYıllarKarlar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GecmisYillarZararlari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DonemNetKarı_Zarari = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YapisalAnalizModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryDates");

            migrationBuilder.DropTable(
                name: "MizanGonderims");

            migrationBuilder.DropTable(
                name: "RasyoModels");

            migrationBuilder.DropTable(
                name: "TekliVeriModels");

            migrationBuilder.DropTable(
                name: "Teminats");

            migrationBuilder.DropTable(
                name: "YapisalAnalizModels");
        }
    }
}
