using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchMNS.Migrations
{
    /// <inheritdoc />
    public partial class TableNameModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientTable_ProfessionnalStatusTable_ProfessionnalStatusId",
                table: "ClientTable");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentTable_ClientTable_ClientId",
                table: "DocumentTable");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentTable_DocumentTypeTable_DocumentTypeId",
                table: "DocumentTable");

            migrationBuilder.DropForeignKey(
                name: "FK_LateMissDocTable_LateMisseTable_LateMissId",
                table: "LateMissDocTable");

            migrationBuilder.DropForeignKey(
                name: "FK_LateMisseTable_ClientTable_ClientId",
                table: "LateMisseTable");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationTable_NotificationTypeTable_NotificationTypeId",
                table: "NotificationTable");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingTable_TrainingTypeTable_TrainingTypeId",
                table: "TrainingTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingTypeTable",
                table: "TrainingTypeTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingTable",
                table: "TrainingTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleTable",
                table: "RoleTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessionnalStatusTable",
                table: "ProfessionnalStatusTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationTypeTable",
                table: "NotificationTypeTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationTable",
                table: "NotificationTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LateMissStatusTable",
                table: "LateMissStatusTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LateMisseTable",
                table: "LateMisseTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LateMissDocTable",
                table: "LateMissDocTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentTypeTable",
                table: "DocumentTypeTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentTable",
                table: "DocumentTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentStatusTable",
                table: "DocumentStatusTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientTable",
                table: "ClientTable");

            migrationBuilder.RenameTable(
                name: "TrainingTypeTable",
                newName: "TrainingType");

            migrationBuilder.RenameTable(
                name: "TrainingTable",
                newName: "Training");

            migrationBuilder.RenameTable(
                name: "RoleTable",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "ProfessionnalStatusTable",
                newName: "ProfessionnalStatus");

            migrationBuilder.RenameTable(
                name: "NotificationTypeTable",
                newName: "NotificationType");

            migrationBuilder.RenameTable(
                name: "NotificationTable",
                newName: "Notification");

            migrationBuilder.RenameTable(
                name: "LateMissStatusTable",
                newName: "LateMissStatus");

            migrationBuilder.RenameTable(
                name: "LateMisseTable",
                newName: "LateMisse");

            migrationBuilder.RenameTable(
                name: "LateMissDocTable",
                newName: "LateMissDoc");

            migrationBuilder.RenameTable(
                name: "DocumentTypeTable",
                newName: "DocumentType");

            migrationBuilder.RenameTable(
                name: "DocumentTable",
                newName: "Document");

            migrationBuilder.RenameTable(
                name: "DocumentStatusTable",
                newName: "DocumentStatus");

            migrationBuilder.RenameTable(
                name: "ClientTable",
                newName: "Client");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingTable_TrainingTypeId",
                table: "Training",
                newName: "IX_Training_TrainingTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationTable_NotificationTypeId",
                table: "Notification",
                newName: "IX_Notification_NotificationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_LateMisseTable_ClientId",
                table: "LateMisse",
                newName: "IX_LateMisse_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_LateMissDocTable_LateMissId",
                table: "LateMissDoc",
                newName: "IX_LateMissDoc_LateMissId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentTable_DocumentTypeId",
                table: "Document",
                newName: "IX_Document_DocumentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentTable_ClientId",
                table: "Document",
                newName: "IX_Document_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientTable_ProfessionnalStatusId",
                table: "Client",
                newName: "IX_Client_ProfessionnalStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingType",
                table: "TrainingType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Training",
                table: "Training",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessionnalStatus",
                table: "ProfessionnalStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationType",
                table: "NotificationType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notification",
                table: "Notification",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LateMissStatus",
                table: "LateMissStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LateMisse",
                table: "LateMisse",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LateMissDoc",
                table: "LateMissDoc",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentType",
                table: "DocumentType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document",
                table: "Document",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentStatus",
                table: "DocumentStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_ProfessionnalStatus_ProfessionnalStatusId",
                table: "Client",
                column: "ProfessionnalStatusId",
                principalTable: "ProfessionnalStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Client_ClientId",
                table: "Document",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_DocumentType_DocumentTypeId",
                table: "Document",
                column: "DocumentTypeId",
                principalTable: "DocumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LateMissDoc_LateMisse_LateMissId",
                table: "LateMissDoc",
                column: "LateMissId",
                principalTable: "LateMisse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LateMisse_Client_ClientId",
                table: "LateMisse",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_NotificationType_NotificationTypeId",
                table: "Notification",
                column: "NotificationTypeId",
                principalTable: "NotificationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Training_TrainingType_TrainingTypeId",
                table: "Training",
                column: "TrainingTypeId",
                principalTable: "TrainingType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_ProfessionnalStatus_ProfessionnalStatusId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_Client_ClientId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_DocumentType_DocumentTypeId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_LateMissDoc_LateMisse_LateMissId",
                table: "LateMissDoc");

            migrationBuilder.DropForeignKey(
                name: "FK_LateMisse_Client_ClientId",
                table: "LateMisse");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_NotificationType_NotificationTypeId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_TrainingType_TrainingTypeId",
                table: "Training");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingType",
                table: "TrainingType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Training",
                table: "Training");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessionnalStatus",
                table: "ProfessionnalStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationType",
                table: "NotificationType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notification",
                table: "Notification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LateMissStatus",
                table: "LateMissStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LateMisse",
                table: "LateMisse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LateMissDoc",
                table: "LateMissDoc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentType",
                table: "DocumentType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentStatus",
                table: "DocumentStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document",
                table: "Document");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.RenameTable(
                name: "TrainingType",
                newName: "TrainingTypeTable");

            migrationBuilder.RenameTable(
                name: "Training",
                newName: "TrainingTable");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "RoleTable");

            migrationBuilder.RenameTable(
                name: "ProfessionnalStatus",
                newName: "ProfessionnalStatusTable");

            migrationBuilder.RenameTable(
                name: "NotificationType",
                newName: "NotificationTypeTable");

            migrationBuilder.RenameTable(
                name: "Notification",
                newName: "NotificationTable");

            migrationBuilder.RenameTable(
                name: "LateMissStatus",
                newName: "LateMissStatusTable");

            migrationBuilder.RenameTable(
                name: "LateMisse",
                newName: "LateMisseTable");

            migrationBuilder.RenameTable(
                name: "LateMissDoc",
                newName: "LateMissDocTable");

            migrationBuilder.RenameTable(
                name: "DocumentType",
                newName: "DocumentTypeTable");

            migrationBuilder.RenameTable(
                name: "DocumentStatus",
                newName: "DocumentStatusTable");

            migrationBuilder.RenameTable(
                name: "Document",
                newName: "DocumentTable");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "ClientTable");

            migrationBuilder.RenameIndex(
                name: "IX_Training_TrainingTypeId",
                table: "TrainingTable",
                newName: "IX_TrainingTable_TrainingTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_NotificationTypeId",
                table: "NotificationTable",
                newName: "IX_NotificationTable_NotificationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_LateMisse_ClientId",
                table: "LateMisseTable",
                newName: "IX_LateMisseTable_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_LateMissDoc_LateMissId",
                table: "LateMissDocTable",
                newName: "IX_LateMissDocTable_LateMissId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_DocumentTypeId",
                table: "DocumentTable",
                newName: "IX_DocumentTable_DocumentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_ClientId",
                table: "DocumentTable",
                newName: "IX_DocumentTable_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Client_ProfessionnalStatusId",
                table: "ClientTable",
                newName: "IX_ClientTable_ProfessionnalStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingTypeTable",
                table: "TrainingTypeTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingTable",
                table: "TrainingTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleTable",
                table: "RoleTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessionnalStatusTable",
                table: "ProfessionnalStatusTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationTypeTable",
                table: "NotificationTypeTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationTable",
                table: "NotificationTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LateMissStatusTable",
                table: "LateMissStatusTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LateMisseTable",
                table: "LateMisseTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LateMissDocTable",
                table: "LateMissDocTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentTypeTable",
                table: "DocumentTypeTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentStatusTable",
                table: "DocumentStatusTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentTable",
                table: "DocumentTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientTable",
                table: "ClientTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTable_ProfessionnalStatusTable_ProfessionnalStatusId",
                table: "ClientTable",
                column: "ProfessionnalStatusId",
                principalTable: "ProfessionnalStatusTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTable_ClientTable_ClientId",
                table: "DocumentTable",
                column: "ClientId",
                principalTable: "ClientTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTable_DocumentTypeTable_DocumentTypeId",
                table: "DocumentTable",
                column: "DocumentTypeId",
                principalTable: "DocumentTypeTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LateMissDocTable_LateMisseTable_LateMissId",
                table: "LateMissDocTable",
                column: "LateMissId",
                principalTable: "LateMisseTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LateMisseTable_ClientTable_ClientId",
                table: "LateMisseTable",
                column: "ClientId",
                principalTable: "ClientTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationTable_NotificationTypeTable_NotificationTypeId",
                table: "NotificationTable",
                column: "NotificationTypeId",
                principalTable: "NotificationTypeTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingTable_TrainingTypeTable_TrainingTypeId",
                table: "TrainingTable",
                column: "TrainingTypeId",
                principalTable: "TrainingTypeTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
