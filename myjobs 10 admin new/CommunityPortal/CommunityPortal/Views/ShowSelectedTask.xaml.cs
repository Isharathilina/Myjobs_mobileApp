﻿using CommunityPortal.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CommunityPortal.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShowSelectedTask : ContentPage
	{
		public ShowSelectedTask ()
		{
			InitializeComponent ();

            GetdataAsync();

        }


        public static MobileServiceClient client = new MobileServiceClient("https://myjobapps.azurewebsites.net");


        IMobileServiceTable<CallerTaskRecord> DataTable = client.GetTable<CallerTaskRecord>();















        public async Task GetdataAsync()
        {
            try
            {



                IMobileServiceTableQuery<CallerTaskRecord> query = DataTable
                .Where(ur => ur.pholdername == tempdata.selected_InvoiceSubject);
                // .Select(todoItem => todoItem.InvoiceSubject);

                List<CallerTaskRecord> items = await query.ToListAsync();
                // EmployeeView.ItemsSource = items2;

                // finalname.Text = string.Format("{0}-{1}", items2[0].FirstName, items2[0].LastName);

                lb1.Text = string.Format("{0} :- {1}", "Holder Name", items[0].pholdername);
                lb2.Text = string.Format("{0} :- {1}", "Address", items[0].Address);
                lb3.Text = string.Format("{0} :- {1}", "Description", items[0].Description);
                lb4.Text = string.Format("{0} :- {1}", "ServiceType", items[0].ServiceType);
                lb5.Text = string.Format("{0} :- {1}", "Budget", items[0].Budget);
                lb6.Text = string.Format("{0} :- {1}", "Due date", items[0].Duedate);

             //   lb7.Text = string.Format("{0} :- {1}", "Assign Status", items[0].AssignStatus);







                tempdata.duedatevr = items[0].Duedate;
                tempdata.WorkPlace = items[0].Address;
                tempdata.servicetype = items[0].ServiceType;
                tempdata.estimatedfee = items[0].Budget;





            }
            catch (Exception e)
            {

                Debug.WriteLine("Sync error: {0}", new[] { e.Message });
            }



        }

      
        private async void Send_Quotation(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SendQuotation(), true);

        }
    }
}