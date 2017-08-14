using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ShopDiaryProjectV1.Adapter;
using Android.Support.V7.Widget;
using ShopDiaryProject.Android.Models.ViewModels;
using ShopDiaryProjectV1.Services;
using ShopDiaryProject.Domain.Models;
using System.Threading;
using Android.Text;


namespace ShopDiaryProjectV1
{
    [Activity(Label = "UseActivity")]
    public class UseActivity : Activity
    {
        #region field
        private InventoryRecycleAdapter mInventoryAdapter;
        private InventoryRecycleAdapterByStorage mInventoryAdapterByStorage;

        public List<InventoryViewModel> mInventories;
        public List<ProductViewModel> mProducts;
        public List<StorageViewModel> mStorages;
        public List<CategoryViewModel> mCategories;

        public InventoryViewModel mInventory;
        public ProductViewModel mProduct;
        public StorageViewModel mStorage;
        public CategoryViewModel mCategory;

        private RecyclerView mListViewInventory;

        private readonly InventoryDataService mInventoryDataService;
        private readonly ProductDataService mProductDataService;
        private readonly CategoryDataService mCategoryDataService;
        private readonly StorageDataService mStorageDataService;
        private readonly ConsumeDataService mConsumeDataService;

        private Spinner mSpinnerStorages;
        private Spinner mSpinnerCategories;
        private ImageButton mButtonBack;
        private Button mButtonUse;
        private Button mButtonDelete;
        private TextView mTextSelectedItem;
        private int mSelectedItem = -1;
        private ProgressDialog mProgressDialog;
        #endregion

        public UseActivity()
        {
            mInventoryDataService = new InventoryDataService();
            mProductDataService = new ProductDataService();
            mCategoryDataService = new CategoryDataService();
            mStorageDataService = new StorageDataService();
            mConsumeDataService = new ConsumeDataService();
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.PageUse);
            InitFields();
        }

        protected override void OnStart()
        {
            base.OnStart();
 
        }
        private void InitFields()
        {
            this.mButtonUse = FindViewById<Button>(Resource.Id.buttonUseUse);
            this.mButtonDelete = FindViewById<Button>(Resource.Id.buttonUseDelete);
            this.mTextSelectedItem = FindViewById<TextView>(Resource.Id.textViewUseSelectedItem);
            this.mListViewInventory = this.FindViewById<RecyclerView>(Resource.Id.recyclerViewUse);
            this.mListViewInventory.SetLayoutManager(new LinearLayoutManager(this));
            this.mSpinnerCategories = FindViewById<Spinner>(Resource.Id.spinnerUseCategorySelected);
            this.mSpinnerStorages = FindViewById<Spinner>(Resource.Id.spinnerUseStorageSelected);
            this.mButtonBack = FindViewById<ImageButton>(Resource.Id.btnUseBack);

            LoadAdapterData();
            LoadItemData();
            mButtonUse.Click += (object sender, EventArgs args) =>
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Confirm Use");
                alert.SetMessage("Use your item?");
                alert.SetPositiveButton("Use It", (senderAlert, eventargs) => 
                {
                    Consume newLoc = new Consume()
                    {
                        DateConsumed = System.DateTime.Now,
                        InventoryId=mInventory.Id

                    };
                    var progressDialog = ProgressDialog.Show(this, "Please wait...", "Consuming...", true);
                    new Thread(new ThreadStart(delegate
                    {

                        var isAdded = mConsumeDataService.Add(newLoc);
                        var isDeleted = mInventoryDataService.Delete(mInventory.Id);
                        RunOnUiThread(() => progressDialog.Hide());

                        if (isAdded)
                        {
                            RunOnUiThread(() => Toast.MakeText(this, "Consumed!", ToastLength.Short).Show());
                        }
                        else
                        {
                            RunOnUiThread(() => Toast.MakeText(this, "Failed to consume, please check your connection", ToastLength.Long).Show());
                        }

                    })).Start();

                   
                });

                alert.SetNegativeButton("Cancel", (senderAlert, eventargs) => {
                    Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
                });

                Dialog dialog = alert.Create();
                dialog.Show();
            };
            mButtonDelete.Click += (object sender, EventArgs args) =>
            {
                var progressDialog = ProgressDialog.Show(this, "Please wait...", "Consuming...", true);
                new Thread(new ThreadStart(delegate
                {  
                    var isDeleted = mInventoryDataService.Delete(mInventory.Id);
                    RunOnUiThread(() => progressDialog.Hide());

                    if (isDeleted)
                    {
                        RunOnUiThread(() => Toast.MakeText(this, "Consumed!", ToastLength.Short).Show());
                    }
                    else
                    {
                        RunOnUiThread(() => Toast.MakeText(this, "Failed to consume, please check your connection", ToastLength.Long).Show());
                    }

                })).Start();
            };
            mButtonBack.Click += (object sender, EventArgs args) =>
            {
                    Intent nextActivity = new Intent(this, typeof(PageMainActivity));
                    StartActivity(nextActivity);
            };
            
        }

        private async void LoadItemData()
        {
            mProgressDialog = ProgressDialog.Show(this, "Please wait...", "Getting data...", true);

            //Spinner Adapter Category
            this.mCategories = await mCategoryDataService.GetAll();
            var adapterCategories = new SpinnerCategoryAdapter(this, mCategories);
            mSpinnerCategories.Adapter = adapterCategories;
            mSpinnerCategories.ItemSelected += SpinnerCategory_ItemSelected;

            //Spinner Adapter Storage
            this.mStorages = await mStorageDataService.GetAll();
            var adapterStorages = new SpinnerStorageAdapter(this, mStorages);
            mSpinnerStorages.Adapter = adapterStorages;
            mSpinnerStorages.ItemSelected += SpinnerStorage_ItemSelected;

            
            mProgressDialog.Hide();
        }
        private async void LoadAdapterData()
        {
            this.mInventories = await mInventoryDataService.GetAll();
            mInventories.Count();
            this.mProducts = await mProductDataService.GetAll();
            //this.mInventories = mInventories.OrderBy(e => e.ItemName).ToList();
            this.mInventories = mInventories.OrderByDescending(e => e.ItemName).ToList();
        }


        private void LoadRecyclerAdapter(StorageViewModel store,CategoryViewModel cat)
        {

            //int i = 0;
            //while (mInventories[i] != null)
            //{
            //    if (store!=null && mInventories[i].StorageId==store.Id)
            //    {
            //        int productCounter = -1;
            //        if (cat!=null && mProducts[productCounter].CategoryId==cat.Id)
            //        {
            //            this.mInventoryAdapter = new InventoryRecycleAdapter(this.mInventories, this.mProducts, this);
            //            this.mInventoryAdapter.ItemClick += OnInventoryClick;
            //            this.mListViewInventory.SetAdapter(this.mInventoryAdapter);
            //        }
            //        productCounter++;
            //    }
            //    else
            //    {
            //        this.mInventoryAdapter = new InventoryRecycleAdapter(this.mInventories, this.mProducts, this);
            //        this.mInventoryAdapter.ItemClick += OnInventoryClick;
            //        this.mListViewInventory.SetAdapter(this.mInventoryAdapter);
            //    }
            //    i++;
            //}
        }

        private void OnInventoryClick(object sender, int e)
        {
            mSelectedItem = e;
        
            mProducts.Count();
            for(int i=0; i > mProducts.Count();i++)
            {
                if(mProducts[i].Id == mInventories[mSelectedItem].ProductId)
                {
                    mTextSelectedItem.Text = mProducts[i].Name;
                }
            }
            mInventory = mInventories[e];

        }

        private void SpinnerStorage_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            
            Spinner spinner = (Spinner)sender;
            mStorage = mStorages[e.Position];
            string toast = string.Format("{0} selected", mStorage.Name);
            Toast.MakeText(this, toast, ToastLength.Long).Show();
            this.mInventoryAdapterByStorage = new InventoryRecycleAdapterByStorage(this.mStorages[e.Position].Id, this.mInventories, this.mProducts, this);
            this.mInventoryAdapterByStorage.ItemClick += OnInventoryClick;
            this.mListViewInventory.SetAdapter(this.mInventoryAdapterByStorage);

        }
        private void SpinnerCategory_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            mCategory = mCategories[e.Position];

            string toast = string.Format("{0} selected", mCategory.Name);
            Toast.MakeText(this, toast, ToastLength.Long).Show();
            //LoadRecyclerAdapter(mStorage, mCategory);

        }

        
    }
}