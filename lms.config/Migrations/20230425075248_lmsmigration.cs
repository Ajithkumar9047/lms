using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lms.config.Migrations
{
    /// <inheritdoc />
    public partial class lmsmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dealer_mediation_controls",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dealerid = table.Column<string>(name: "dealer_id", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    pushedcount = table.Column<int>(name: "pushed_count", type: "int", nullable: true),
                    maxcount = table.Column<int>(name: "max_count", type: "int", nullable: true),
                    createdon = table.Column<DateTime>(name: "created_on", type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__dealer_m__3213E83F801D71AE", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DealerMasterList",
                columns: table => new
                {
                    dealercode = table.Column<double>(name: "dealer_code", type: "float", nullable: true),
                    branchid = table.Column<double>(name: "branch_id", type: "float", nullable: true),
                    dealername = table.Column<string>(name: "dealer_name", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealerspocname = table.Column<string>(name: "dealer_spoc_name", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealernewspocnumbers = table.Column<double>(name: "dealer_new_spoc_numbers", type: "float", nullable: true),
                    dealeralternatemobileno = table.Column<string>(name: "dealer_alternate_mobile_no", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealeremailid = table.Column<string>(name: "dealer_emailid", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealeralternateemailid = table.Column<string>(name: "dealer_alternate_emailid", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealeraddress = table.Column<string>(name: "dealer_address", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealerterritory = table.Column<string>(name: "dealer_territory", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealerarea2 = table.Column<string>(name: "dealer_area_2", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealertown = table.Column<string>(name: "dealer_town", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealerpincode = table.Column<double>(name: "dealer_pincode", type: "float", nullable: true),
                    dealerstate = table.Column<string>(name: "dealer_state", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealerzone = table.Column<string>(name: "dealer_zone", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealerarea = table.Column<string>(name: "dealer_area", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealertmname = table.Column<string>(name: "dealer_tm_name", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealertmemail = table.Column<string>(name: "dealer_tm_email", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealeramname = table.Column<string>(name: "dealer_am_name", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealeramemail = table.Column<string>(name: "dealer_am_email", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealerismname = table.Column<string>(name: "dealer_ism_name", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealerismemail = table.Column<string>(name: "dealer_ism_email", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealernsmname = table.Column<string>(name: "dealer_nsm_name", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealernsmemail = table.Column<string>(name: "dealer_nsm_email", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealerzonalplannername = table.Column<string>(name: "dealer_zonal_planner_name", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealerzonalplanneremail = table.Column<string>(name: "dealer_zonal_planner_email", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealerleadcity = table.Column<string>(name: "dealer_lead_city", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dealertype = table.Column<string>(name: "dealer_type", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    thresholdcount = table.Column<double>(name: "threshold_count", type: "float", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "lead_logs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    leadsource = table.Column<string>(name: "lead_source", type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    request = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    createdon = table.Column<DateTime>(name: "created_on", type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    processed = table.Column<bool>(type: "bit", nullable: false),
                    error = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_id_lead_logs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "error_leads",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    leadlogid = table.Column<long>(name: "lead_log_id", type: "bigint", nullable: false),
                    errordescription = table.Column<string>(name: "error_description", type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__error_le__3213E83FBAF616AE", x => x.id);
                    table.ForeignKey(
                        name: "FK__error_lea__lead___3C69FB99",
                        column: x => x.leadlogid,
                        principalTable: "lead_logs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "leads",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    leadlogid = table.Column<long>(name: "lead_log_id", type: "bigint", nullable: false),
                    dealerid = table.Column<string>(name: "dealer_id", type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    partid = table.Column<string>(name: "part_id", type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    modelid = table.Column<string>(name: "model_id", type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    isemsdealer = table.Column<bool>(name: "is_ems_dealer", type: "bit", nullable: false),
                    isfinance = table.Column<bool>(name: "is_finance", type: "bit", nullable: false),
                    processed = table.Column<bool>(type: "bit", nullable: false),
                    agencycode = table.Column<string>(name: "agency_code", type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__leads__3213E83F2C242269", x => x.id);
                    table.ForeignKey(
                        name: "FK__leads__lead_log___403A8C7D",
                        column: x => x.leadlogid,
                        principalTable: "lead_logs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "classified_leads",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    leadid = table.Column<long>(name: "lead_id", type: "bigint", nullable: false),
                    probability = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    leadtype = table.Column<string>(name: "lead_type", type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    createdon = table.Column<DateTime>(name: "created_on", type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__classifi__3213E83F9C35887E", x => x.id);
                    table.ForeignKey(
                        name: "FK__classifie__lead___4CA06362",
                        column: x => x.leadid,
                        principalTable: "leads",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "crm_push_logs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    leadid = table.Column<long>(name: "lead_id", type: "bigint", nullable: false),
                    payload = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    response = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    createdon = table.Column<DateTime>(name: "created_on", type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__crm_push__3213E83FC10B6361", x => x.id);
                    table.ForeignKey(
                        name: "FK__crm_push___lead___60A75C0F",
                        column: x => x.leadid,
                        principalTable: "leads",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "dms_push_logs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    leadid = table.Column<long>(name: "lead_id", type: "bigint", nullable: false),
                    dealerid = table.Column<string>(name: "dealer_id", type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    internetenquiryid = table.Column<string>(name: "internet_enquiry_id", type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    payload = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    response = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    createdon = table.Column<DateTime>(name: "created_on", type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__dms_push__3213E83F9AD0678A", x => x.id);
                    table.ForeignKey(
                        name: "FK__dms_push___lead___5BE2A6F2",
                        column: x => x.leadid,
                        principalTable: "leads",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ems_push_logs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    leadid = table.Column<long>(name: "lead_id", type: "bigint", nullable: false),
                    internetenquiryid = table.Column<string>(name: "internet_enquiry_id", type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    payload = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    response = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    createdon = table.Column<DateTime>(name: "created_on", type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ems_push__3213E83F57A30780", x => x.id);
                    table.ForeignKey(
                        name: "FK__ems_push___lead___571DF1D5",
                        column: x => x.leadid,
                        principalTable: "leads",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "finance_push_logs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    leadid = table.Column<long>(name: "lead_id", type: "bigint", nullable: false),
                    financepartner = table.Column<string>(name: "finance_partner", type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    response = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    createdon = table.Column<DateTime>(name: "created_on", type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__finance___3213E83F209B10A6", x => x.id);
                    table.ForeignKey(
                        name: "FK__finance_p__lead___52593CB8",
                        column: x => x.leadid,
                        principalTable: "leads",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_classified_leads_lead_id",
                table: "classified_leads",
                column: "lead_id");

            migrationBuilder.CreateIndex(
                name: "IX_crm_push_logs_lead_id",
                table: "crm_push_logs",
                column: "lead_id");

            migrationBuilder.CreateIndex(
                name: "IX_dms_push_logs_lead_id",
                table: "dms_push_logs",
                column: "lead_id");

            migrationBuilder.CreateIndex(
                name: "IX_ems_push_logs_lead_id",
                table: "ems_push_logs",
                column: "lead_id");

            migrationBuilder.CreateIndex(
                name: "IX_error_leads_lead_log_id",
                table: "error_leads",
                column: "lead_log_id");

            migrationBuilder.CreateIndex(
                name: "IX_finance_push_logs_lead_id",
                table: "finance_push_logs",
                column: "lead_id");

            migrationBuilder.CreateIndex(
                name: "IX_leads_lead_log_id",
                table: "leads",
                column: "lead_log_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classified_leads");

            migrationBuilder.DropTable(
                name: "crm_push_logs");

            migrationBuilder.DropTable(
                name: "dealer_mediation_controls");

            migrationBuilder.DropTable(
                name: "DealerMasterList");

            migrationBuilder.DropTable(
                name: "dms_push_logs");

            migrationBuilder.DropTable(
                name: "ems_push_logs");

            migrationBuilder.DropTable(
                name: "error_leads");

            migrationBuilder.DropTable(
                name: "finance_push_logs");

            migrationBuilder.DropTable(
                name: "leads");

            migrationBuilder.DropTable(
                name: "lead_logs");
        }
    }
}
