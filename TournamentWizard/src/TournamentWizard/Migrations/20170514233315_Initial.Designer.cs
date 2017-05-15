using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using TournamentWizard.Models;

namespace TournamentWizard.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20170514233315_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TournamentWizard.Models.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbreviation");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TournamentWizard.Models.LeagueCompetitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("TeamId");

                    b.Property<int?>("TournamentId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TournamentWizard.Models.LeagueTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("LeagueId");

                    b.Property<string>("Name");

                    b.Property<string>("Nickname");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TournamentWizard.Models.LeagueTournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("LeagueId");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TournamentWizard.Models.LeagueTournamentLines", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CompetitorId");

                    b.Property<DateTime?>("Created");

                    b.Property<int>("LineNumber");

                    b.Property<int?>("TournamentId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TournamentWizard.Models.LeagueCompetitor", b =>
                {
                    b.HasOne("TournamentWizard.Models.LeagueTeam")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.HasOne("TournamentWizard.Models.LeagueTournament")
                        .WithMany()
                        .HasForeignKey("TournamentId");
                });

            modelBuilder.Entity("TournamentWizard.Models.LeagueTeam", b =>
                {
                    b.HasOne("TournamentWizard.Models.League")
                        .WithMany()
                        .HasForeignKey("LeagueId");
                });

            modelBuilder.Entity("TournamentWizard.Models.LeagueTournament", b =>
                {
                    b.HasOne("TournamentWizard.Models.League")
                        .WithMany()
                        .HasForeignKey("LeagueId");
                });

            modelBuilder.Entity("TournamentWizard.Models.LeagueTournamentLines", b =>
                {
                    b.HasOne("TournamentWizard.Models.LeagueCompetitor")
                        .WithMany()
                        .HasForeignKey("CompetitorId");

                    b.HasOne("TournamentWizard.Models.LeagueTournament")
                        .WithMany()
                        .HasForeignKey("TournamentId");
                });
        }
    }
}
