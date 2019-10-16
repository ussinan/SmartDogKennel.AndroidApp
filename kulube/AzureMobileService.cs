
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;
using System.IO;

using System.Collections.Generic;



namespace kulube
{
    public class AzureMobileService
    {
        public MobileServiceClient Client { get; private set; }
        private IMobileServiceSyncTable<KULUBEBILGI> KULUBEBILGITABLO;

        private async Task Initialize()
        {
            Client = new MobileServiceClient("https://paticlub.azurewebsites.net");

            var path = Path.Combine(MobileServiceClient.DefaultDatabasePath, "KULUBEDB.db");

            var store = new MobileServiceSQLiteStore(path);

            store.DefineTable<KULUBEBILGI>();

            await Client.SyncContext.InitializeAsync(store);

            KULUBEBILGITABLO = Client.GetSyncTable<KULUBEBILGI>();
        }

        private async Task SyncKULUBEBILGI()
        {
            await KULUBEBILGITABLO.PullAsync("KULUBEDB.db", KULUBEBILGITABLO.CreateQuery());
            await Client.SyncContext.PushAsync();
        }

        private async Task<List<KULUBEBILGI>> TabloCek()
        {
            await SyncKULUBEBILGI();
            return await KULUBEBILGITABLO.ToListAsync();
        }

    }
}