using HastaneRandevuSistemiAPI.Repositories.Abstract;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

public class CleanupAppointmentsService : IHostedService, IDisposable
{
    private readonly IServiceProvider _serviceProvider;
    private Timer _timer;

    public CleanupAppointmentsService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        // Zamanlayıcıyı başlat
        _timer = new Timer(async _ => await CleanupExpiredAppointments(), null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        // Zamanlayıcıyı durdur
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public async Task CleanupExpiredAppointments()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var appointmentRepository = scope.ServiceProvider.GetRequiredService<IAppointmentRepository>();

            // Geçmiş tarihli randevuları sil
            var expiredAppointments = await appointmentRepository.GetExpiredAppointmentsAsync();

            if (expiredAppointments != null && expiredAppointments.Count > 0)
            {
                foreach (var appointment in expiredAppointments)
                {
                    await appointmentRepository.DeleteAsync(appointment.Id); // appointment.Id ile geçerli randevu ID'sini geçin.
                }
            }
        }
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
