using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApp.BLL.Contracts;
using WebApp.BLL.Implementations;
using WebApp.DAL;
using WebApp.DAL.Entities;
using WebApp.Domain.Contracts;
using WebApp.Domain.Models;
using IPaymentRep =
    WebApp.DAL.IRepository<WebApp.Domain.Payment, WebApp.Domain.Contracts.IPaymentContainer,
        WebApp.Domain.Models.PaymentUpdateModel>;
using IRoomRep =
    WebApp.DAL.IRepository<WebApp.Domain.Room, WebApp.Domain.Contracts.IRoomContainer,
        WebApp.Domain.Models.RoomUpdateModel>;
using IBookingRep =
    WebApp.DAL.IRepository<WebApp.Domain.Booking, WebApp.Domain.Contracts.IBookingContainer,
        WebApp.Domain.Models.BookingUpdateModel>;
using IRoomTypeRep =
    WebApp.DAL.IRepository<WebApp.Domain.RoomType, WebApp.Domain.Contracts.IRoomTypeContainer,
        WebApp.Domain.Models.RoomTypeUpdateModel>;


namespace WebApp.WebAPI {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddLogging();
            // Get, Create, Update, Delete Services
            // Client
            services.AddScoped<IGetService<IClientContainer, WebApp.Domain.Client>, ClientGetService>();
            services
                .AddScoped<ICreateService<ClientUpdateModel, IClientContainer, WebApp.Domain.Client>,
                    ClientCreateService>();
            services
                .AddScoped<IUpdateService<ClientUpdateModel, IClientContainer, WebApp.Domain.Client>,
                    ClientUpdateService>();
            services.AddScoped<IDeleteService<IClientContainer>, ClientDeleteService>();

            // Payment
            services.AddScoped<IGetService<IPaymentContainer, WebApp.Domain.Payment>, PaymentGetService>();
            services
                .AddScoped<ICreateService<PaymentUpdateModel, IPaymentContainer, WebApp.Domain.Payment>,
                    PaymentCreateService>();
            services
                .AddScoped<IUpdateService<PaymentUpdateModel, IPaymentContainer, WebApp.Domain.Payment>,
                    PaymentUpdateService>();
            services.AddScoped<IDeleteService<IPaymentContainer>, PaymentDeleteService>();

            // Booking
            services.AddScoped<IGetService<IBookingContainer, WebApp.Domain.Booking>, BookingGetService>();
            services
                .AddScoped<ICreateService<BookingUpdateModel, IBookingContainer, WebApp.Domain.Booking>,
                    BookingCreateService>();
            services
                .AddScoped<IUpdateService<BookingUpdateModel, IBookingContainer, WebApp.Domain.Booking>,
                    BookingUpdateService>();
            services.AddScoped<IDeleteService<IBookingContainer>, BookingDeleteService>();

            // Room
            services.AddScoped<IGetService<IRoomContainer, WebApp.Domain.Room>, RoomGetService>();
            services
                .AddScoped<ICreateService<RoomUpdateModel, IRoomContainer, WebApp.Domain.Room>,
                    RoomCreateService>();
            services
                .AddScoped<IUpdateService<RoomUpdateModel, IRoomContainer, WebApp.Domain.Room>,
                    RoomUpdateService>();
            services.AddScoped<IDeleteService<IRoomContainer>, RoomDeleteService>();

            // RoomType
            services.AddScoped<IGetService<IRoomTypeContainer, WebApp.Domain.RoomType>, RoomTypeGetService>();
            services
                .AddScoped<ICreateService<RoomTypeUpdateModel, IRoomTypeContainer, WebApp.Domain.RoomType>,
                    RoomTypeCreateService>();
            services
                .AddScoped<IUpdateService<RoomTypeUpdateModel, IRoomTypeContainer, WebApp.Domain.RoomType>,
                    RoomTypeUpdateService>();
            services.AddScoped<IDeleteService<IRoomTypeContainer>, RoomTypeDeleteService>();

            // DataAccess
            services.Add(new ServiceDescriptor(typeof(IClientRepository),
                typeof(ClientRepository), ServiceLifetime.Transient));
            services.AddTransient<IPaymentRep, PaymentRepository>();
            services.AddTransient<IBookingRep, BookingRepository>();
            services.AddTransient<IRoomRep, RoomRepository>();
            services.AddTransient<IRoomTypeRep, RoomTypeRepo>();
            // services.Add(new ServiceDescriptor(typeof(IDepartmentDataAccess), typeof(DepartmentDataAccess), ServiceLifetime.Transient));

            // DB Contexts
            services.AddDbContext<HotelDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}