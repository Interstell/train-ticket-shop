using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrainTicketShop.Migrations
{
    public partial class TicketAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthDate = table.Column<string>(nullable: true),
                    BoughtDate = table.Column<string>(nullable: false),
                    CarriageNumber = table.Column<string>(nullable: false),
                    CarriageType = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Hash = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PassengerType = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    SeatNumber = table.Column<int>(nullable: false),
                    StudentsCardId = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: false),
                    TrainArrivalStation = table.Column<string>(nullable: true),
                    TrainArrivalStationId = table.Column<int>(nullable: false),
                    TrainCategory = table.Column<string>(nullable: true),
                    TrainClass = table.Column<string>(nullable: true),
                    TrainDepartureStation = table.Column<string>(nullable: true),
                    TrainDepartureStationId = table.Column<int>(nullable: false),
                    TrainModel = table.Column<string>(nullable: true),
                    TrainNumber = table.Column<string>(nullable: true),
                    TrainPassengerArrivalDate = table.Column<string>(nullable: true),
                    TrainPassengerArrivalStation = table.Column<string>(nullable: true),
                    TrainPassengerArrivalStationId = table.Column<int>(nullable: false),
                    TrainPassengerDepartureDate = table.Column<string>(nullable: true),
                    TrainPassengerDepartureStation = table.Column<string>(nullable: true),
                    TrainPassengerDepartureStationId = table.Column<int>(nullable: false),
                    TrainTravelTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
