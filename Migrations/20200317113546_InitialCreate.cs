using Microsoft.EntityFrameworkCore.Migrations;

namespace jsonWebApiProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TemplateOptions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Required = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Placeholder = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormlyConfig",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TemplateOptionsId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormlyConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormlyConfig_TemplateOptions_TemplateOptionsId",
                        column: x => x.TemplateOptionsId,
                        principalTable: "TemplateOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Option",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    TemplateOptionsId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Option_TemplateOptions_TemplateOptionsId",
                        column: x => x.TemplateOptionsId,
                        principalTable: "TemplateOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Widget",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FormlyConfigId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Widget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Widget_FormlyConfig_FormlyConfigId",
                        column: x => x.FormlyConfigId,
                        principalTable: "FormlyConfig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    WidgetId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Property_Widget_WidgetId",
                        column: x => x.WidgetId,
                        principalTable: "Widget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DependencyProperties",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TitleId = table.Column<string>(nullable: true),
                    DetailsId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependencyProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DependencyProperties_Property_DetailsId",
                        column: x => x.DetailsId,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DependencyProperties_Property_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FullnameId = table.Column<string>(nullable: true),
                    EmailId = table.Column<string>(nullable: true),
                    Date_of_birthId = table.Column<string>(nullable: true),
                    CountryId = table.Column<string>(nullable: true),
                    Have_childrenId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Property_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Properties_Property_Date_of_birthId",
                        column: x => x.Date_of_birthId,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Properties_Property_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Properties_Property_FullnameId",
                        column: x => x.FullnameId,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Properties_Property_Have_childrenId",
                        column: x => x.Have_childrenId,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DependenciesSchema",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    PropertiesId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependenciesSchema", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DependenciesSchema_DependencyProperties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "DependencyProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ItemsId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Children_DependenciesSchema_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "DependenciesSchema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Default",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ChildrenId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Default", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Default_Children_ChildrenId",
                        column: x => x.ChildrenId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HaveProperties",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    childrenId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HaveProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HaveProperties_Children_childrenId",
                        column: x => x.childrenId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HaveChildren",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PropertiesId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HaveChildren", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HaveChildren_HaveProperties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "HaveProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dependencies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Have_childrenId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dependencies_HaveChildren_Have_childrenId",
                        column: x => x.Have_childrenId,
                        principalTable: "HaveChildren",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schema",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    PropertiesId = table.Column<string>(nullable: true),
                    DependenciesId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schema", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schema_Dependencies_DependenciesId",
                        column: x => x.DependenciesId,
                        principalTable: "Dependencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schema_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JsonSchema",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SchemaId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JsonSchema", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JsonSchema_Schema_SchemaId",
                        column: x => x.SchemaId,
                        principalTable: "Schema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Children_ItemsId",
                table: "Children",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Default_ChildrenId",
                table: "Default",
                column: "ChildrenId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependencies_Have_childrenId",
                table: "Dependencies",
                column: "Have_childrenId");

            migrationBuilder.CreateIndex(
                name: "IX_DependenciesSchema_PropertiesId",
                table: "DependenciesSchema",
                column: "PropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_DependencyProperties_DetailsId",
                table: "DependencyProperties",
                column: "DetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_DependencyProperties_TitleId",
                table: "DependencyProperties",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_FormlyConfig_TemplateOptionsId",
                table: "FormlyConfig",
                column: "TemplateOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_HaveChildren_PropertiesId",
                table: "HaveChildren",
                column: "PropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_HaveProperties_childrenId",
                table: "HaveProperties",
                column: "childrenId");

            migrationBuilder.CreateIndex(
                name: "IX_JsonSchema_SchemaId",
                table: "JsonSchema",
                column: "SchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Option_TemplateOptionsId",
                table: "Option",
                column: "TemplateOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CountryId",
                table: "Properties",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_Date_of_birthId",
                table: "Properties",
                column: "Date_of_birthId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_EmailId",
                table: "Properties",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_FullnameId",
                table: "Properties",
                column: "FullnameId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_Have_childrenId",
                table: "Properties",
                column: "Have_childrenId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_WidgetId",
                table: "Property",
                column: "WidgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Schema_DependenciesId",
                table: "Schema",
                column: "DependenciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Schema_PropertiesId",
                table: "Schema",
                column: "PropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Widget_FormlyConfigId",
                table: "Widget",
                column: "FormlyConfigId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Default");

            migrationBuilder.DropTable(
                name: "JsonSchema");

            migrationBuilder.DropTable(
                name: "Option");

            migrationBuilder.DropTable(
                name: "Schema");

            migrationBuilder.DropTable(
                name: "Dependencies");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "HaveChildren");

            migrationBuilder.DropTable(
                name: "HaveProperties");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "DependenciesSchema");

            migrationBuilder.DropTable(
                name: "DependencyProperties");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "Widget");

            migrationBuilder.DropTable(
                name: "FormlyConfig");

            migrationBuilder.DropTable(
                name: "TemplateOptions");
        }
    }
}
