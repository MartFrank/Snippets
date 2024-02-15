var fileName = string.Format("{0}\\fileNameHere", Directory.GetCurrentDirectory());
var connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", fileName);

var adapter = new OleDbDataAdapter("SELECT * FROM [workSheetNameHere$]", connectionString);
var ds = new DataSet();

adapter.Fill(ds, "anyNameHere");

var data = ds.Tables["anyNameHere"].AsEnumerable();

var query = data.Where(x => x.Field<string>("phoneNumber") != string.Empty).Select(x =>
                new MyContact
                    {
                        firstName= x.Field<string>("First Name"),
                        lastName = x.Field<string>("Last Name"),
                        phoneNumber =x.Field<string>("Phone Number"),
                    });
