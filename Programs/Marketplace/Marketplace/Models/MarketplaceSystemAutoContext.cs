using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Models;

public partial class MarketplaceSystemAutoContext : DbContext
{
    public MarketplaceSystemAutoContext()
    {
    }

    public MarketplaceSystemAutoContext(DbContextOptions<MarketplaceSystemAutoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrator> Administrators { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<DictionaryStatusHistory> DictionaryStatusHistories { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<PresentCard> PresentCards { get; set; }

    public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }

    public virtual DbSet<ProductAttributeCategory> ProductAttributeCategories { get; set; }

    public virtual DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }

    public virtual DbSet<ProductPlace> ProductPlaces { get; set; }

    public virtual DbSet<ProductPrice> ProductPrices { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    public virtual DbSet<StatusHistoryOrderId> StatusHistoryOrderIds { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskCompletionStatus> TaskCompletionStatuses { get; set; }

    public virtual DbSet<TaskHistory> TaskHistories { get; set; }

    public virtual DbSet<UserMarket> UserMarkets { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<WorkLog> WorkLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog='Marketplace_system_auto';Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Administ__43AA41412A213204");

            entity.ToTable("Administrator");

            entity.HasIndex(e => e.Email, "IX_Administrator_email");

            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__2EF52A274EF1861A");

            entity.ToTable("Cart");

            entity.Property(e => e.CartId).HasColumnName("cart_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart__user_id__6C190EBB");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId).HasName("PK__Cart_Ite__5D9A6C6EF0FE1378");

            entity.ToTable("Cart_Item");

            entity.Property(e => e.CartItemId).HasColumnName("cart_item_id");
            entity.Property(e => e.CartId).HasColumnName("cart_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart_Item__cart___6EF57B66");

            entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart_Item__produ__6FE99F9F");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__D54EE9B4C189CBF6");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DictionaryStatusHistory>(entity =>
        {
            entity.HasKey(e => e.DictionaryStatusHistoryId).HasName("PK__Dictiona__8854329FFE5934B1");

            entity.ToTable("Dictionary_Status_History");

            entity.Property(e => e.DictionaryStatusHistoryId).HasColumnName("dictionary_status_history_id");
            entity.Property(e => e.TitleStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title_status");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__C52E0BA868D0899E");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.Email, "IX_Employee_email");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.DateDismissal).HasColumnName("date_dismissal");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.HireDate).HasColumnName("hire_date");
            entity.Property(e => e.IdAdministrator).HasColumnName("id_administrator");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Position)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("position");
            entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");

            entity.HasOne(d => d.IdAdministratorNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdAdministrator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employee__id_adm__01142BA1");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Employees)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employee__wareho__02084FDA");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__465962299FFF74C8");

            entity.ToTable("Order");

            entity.HasIndex(e => e.UserId, "IX_Order_user_id");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__user_id__73BA3083");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__Order_It__3764B6BC36F4E68F");

            entity.ToTable("Order_Items");

            entity.HasIndex(e => e.OrderId, "IX_Order_Items_order_id");

            entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.PresentCardId).HasColumnName("present_card_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order_Ite__order__76969D2E");

            entity.HasOne(d => d.PresentCard).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.PresentCardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order_Ite__prese__778AC167");
        });

        modelBuilder.Entity<PresentCard>(entity =>
        {
            entity.HasKey(e => e.PresentCardId).HasName("PK__Present___90C86C09E68B9393");

            entity.ToTable("Present_Card");

            entity.HasIndex(e => e.SellerId, "IX_Present_Card_seller_id");

            entity.Property(e => e.PresentCardId).HasColumnName("present_card_id");
            entity.Property(e => e.Brand)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("brand");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Images).HasColumnName("images");
            entity.Property(e => e.IsAvailable)
                .HasDefaultValue(true)
                .HasColumnName("is_available");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.SellerId).HasColumnName("seller_id");

            entity.HasOne(d => d.Seller).WithMany(p => p.PresentCards)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Present_C__selle__5535A963");
        });

        modelBuilder.Entity<ProductAttribute>(entity =>
        {
            entity.HasKey(e => e.AttributeId).HasName("PK__Product___9090C9BB878F4D9E");

            entity.ToTable("Product_Attribute");

            entity.Property(e => e.AttributeId).HasColumnName("attribute_id");
            entity.Property(e => e.DataType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("data_type");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Unit)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("unit");
        });

        modelBuilder.Entity<ProductAttributeCategory>(entity =>
        {
            entity.HasKey(e => e.AttributeCategoryId).HasName("PK__Product___96840F096BB6FE67");

            entity.ToTable("Product_Attribute__Category");

            entity.Property(e => e.AttributeCategoryId).HasColumnName("attribute_category_id");
            entity.Property(e => e.AttributeId).HasColumnName("attribute_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");

            entity.HasOne(d => d.Attribute).WithMany(p => p.ProductAttributeCategories)
                .HasForeignKey(d => d.AttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_A__attri__59FA5E80");

            entity.HasOne(d => d.Category).WithMany(p => p.ProductAttributeCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_A__categ__5AEE82B9");
        });

        modelBuilder.Entity<ProductAttributeValue>(entity =>
        {
            entity.HasKey(e => e.AttributeValueId).HasName("PK__Product___C817A2F6392DF34F");

            entity.ToTable("Product_Attribute_Value");

            entity.Property(e => e.AttributeValueId).HasColumnName("attribute_value_id");
            entity.Property(e => e.AttributeCategoryId).HasColumnName("attribute_category_id");
            entity.Property(e => e.PresentCardId).HasColumnName("present_card_id");
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("value");

            entity.HasOne(d => d.AttributeCategory).WithMany(p => p.ProductAttributeValues)
                .HasForeignKey(d => d.AttributeCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_A__attri__5EBF139D");

            entity.HasOne(d => d.PresentCard).WithMany(p => p.ProductAttributeValues)
                .HasForeignKey(d => d.PresentCardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_A__prese__5DCAEF64");
        });

        modelBuilder.Entity<ProductPlace>(entity =>
        {
            entity.HasKey(e => e.IdProductPlace).HasName("PK__Product___A1A7EBAE97F5526E");

            entity.ToTable("Product_place");

            entity.Property(e => e.IdProductPlace).HasColumnName("id_product_place");
            entity.Property(e => e.IdWarehouse).HasColumnName("id_warehouse");
            entity.Property(e => e.PresentCardId).HasColumnName("present_card_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Shelf)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("shelf");
            entity.Property(e => e.Shelving)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("shelving");

            entity.HasOne(d => d.IdWarehouseNavigation).WithMany(p => p.ProductPlaces)
                .HasForeignKey(d => d.IdWarehouse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_p__id_wa__656C112C");

            entity.HasOne(d => d.PresentCard).WithMany(p => p.ProductPlaces)
                .HasForeignKey(d => d.PresentCardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_p__prese__6477ECF3");
        });

        modelBuilder.Entity<ProductPrice>(entity =>
        {
            entity.HasKey(e => e.ProductPriceId).HasName("PK__Product___89EF5AE8BB7085D5");

            entity.ToTable("Product_price");

            entity.Property(e => e.ProductPriceId).HasColumnName("Product_price_id");
            entity.Property(e => e.PresentCardId).HasColumnName("present_card_id");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.PresentCard).WithMany(p => p.ProductPrices)
                .HasForeignKey(d => d.PresentCardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_p__prese__619B8048");
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasKey(e => e.SellerId).HasName("PK__Seller__780A0A97741DDF2F");

            entity.ToTable("Seller");

            entity.HasIndex(e => e.Email, "IX_Seller_email");

            entity.Property(e => e.SellerId).HasColumnName("seller_id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("company_name");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Inn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("INN");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<StatusHistoryOrderId>(entity =>
        {
            entity.HasKey(e => e.StatusHistoryId).HasName("PK__Dictiona__5D0007BE1627753A");

            entity.ToTable("Status_History_order_id");

            entity.Property(e => e.StatusHistoryId).HasColumnName("status_history_id");
            entity.Property(e => e.DateEdit)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date_edit");
            entity.Property(e => e.DictionaryStatusHistoryId).HasColumnName("dictionary_status_history_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");

            entity.HasOne(d => d.DictionaryStatusHistory).WithMany(p => p.StatusHistoryOrderIds)
                .HasForeignKey(d => d.DictionaryStatusHistoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Dictionar__dicti__7E37BEF6");

            entity.HasOne(d => d.Order).WithMany(p => p.StatusHistoryOrderIds)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Dictionar__order__7D439ABD");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Task__0492148D4D925446");

            entity.ToTable("Task");

            entity.HasIndex(e => e.EmployeeId, "IX_Task_employee_id");

            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.ActualHourseWork).HasColumnName("actual_hourse_work");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.OrderItemsId).HasColumnName("order_items_id");
            entity.Property(e => e.Priority)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("priority");
            entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Task__employee_i__06CD04F7");

            entity.HasOne(d => d.OrderItems).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.OrderItemsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Task__order_item__07C12930");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Task__warehouse___08B54D69");
        });

        modelBuilder.Entity<TaskCompletionStatus>(entity =>
        {
            entity.HasKey(e => e.StatusTaskId).HasName("PK__Task_Com__136782FEA03B15E3");

            entity.ToTable("Task_Completion_Status");

            entity.Property(e => e.StatusTaskId).HasColumnName("status_task_id");
            entity.Property(e => e.TitleStatusId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title_status_id");
        });

        modelBuilder.Entity<TaskHistory>(entity =>
        {
            entity.HasKey(e => e.HistoryId).HasName("PK__Task_His__096AA2E9E9888C09");

            entity.ToTable("Task_History");

            entity.Property(e => e.HistoryId).HasColumnName("history_id");
            entity.Property(e => e.ChangedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("changed_at");
            entity.Property(e => e.StatusTaskId).HasColumnName("status_task_id");
            entity.Property(e => e.TaskId).HasColumnName("task_id");

            entity.HasOne(d => d.StatusTask).WithMany(p => p.TaskHistories)
                .HasForeignKey(d => d.StatusTaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Task_Hist__statu__0D7A0286");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskHistories)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Task_Hist__task___0C85DE4D");
        });

        modelBuilder.Entity<UserMarket>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__User_mar__D2D146373A406898");

            entity.ToTable("User_market");

            entity.HasIndex(e => e.Email, "IX_User_market_email");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.WarehouseId).HasName("PK__Warehous__734FE6BF05E08175");

            entity.ToTable("Warehouse");

            entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.SellerId).HasColumnName("seller_id");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasOne(d => d.Seller).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK__Warehouse__selle__5070F446");
        });

        modelBuilder.Entity<WorkLog>(entity =>
        {
            entity.HasKey(e => e.WorkLogId).HasName("PK__Work_Log__07D586E0E4AED14F");

            entity.ToTable("Work_Log");

            entity.HasIndex(e => e.EmployeeId, "IX_Work_Log_employee_id");

            entity.HasIndex(e => e.WorkDate, "IX_Work_Log_work_date");

            entity.Property(e => e.WorkLogId).HasColumnName("work_log_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.HoursSpent).HasColumnName("hours_spent");
            entity.Property(e => e.QuantityTask).HasColumnName("quantity_task");
            entity.Property(e => e.WorkDate).HasColumnName("work_date");

            entity.HasOne(d => d.Employee).WithMany(p => p.WorkLogs)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Work_Log__employ__10566F31");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
