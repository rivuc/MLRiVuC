


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using System.Linq.Expressions;
using SubSonic.Schema;
using System.Collections;
using SubSonic;
using SubSonic.Repository;
using System.ComponentModel;
using System.Data.Common;

namespace DAL
{
    
    
    /// <summary>
    /// A class which represents the Operaciones table in the ML Database.
    /// </summary>
    public partial class Operacione: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Operacione> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Operacione>(new DAL.MLDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Operacione> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Operacione item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Operacione item=new Operacione();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Operacione> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        DAL.MLDB _db;
        public Operacione(string connectionString, string providerName) {

            _db=new DAL.MLDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Operacione.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Operacione>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Operacione(){
             _db=new DAL.MLDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Operacione(Expression<Func<Operacione, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Operacione> GetRepo(string connectionString, string providerName){
            DAL.MLDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new DAL.MLDB();
            }else{
                db=new DAL.MLDB(connectionString, providerName);
            }
            IRepository<Operacione> _repo;
            
            if(db.TestMode){
                Operacione.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Operacione>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Operacione> GetRepo(){
            return GetRepo("","");
        }
        
        public static Operacione SingleOrDefault(Expression<Func<Operacione, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Operacione single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Operacione SingleOrDefault(Expression<Func<Operacione, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Operacione single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Operacione, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Operacione, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Operacione> Find(Expression<Func<Operacione, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Operacione> Find(Expression<Func<Operacione, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Operacione> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Operacione> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Operacione> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Operacione> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Operacione> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Operacione> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Operacion";
        }

        public object KeyValue()
        {
            return this.Operacion;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.Operacion.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Operacione)){
                Operacione compare=(Operacione)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.Operacion.ToString();
        }

        public string DescriptorColumn() {
            return "Operacion";
        }
        public static string GetKeyColumn()
        {
            return "Operacion";
        }        
        public static string GetDescriptorColumn()
        {
            return "Operacion";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        string _Operacion;
        public string Operacion
        {
            get { return _Operacion; }
            set
            {
                if(_Operacion!=value){
                    _Operacion=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Operacion");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Operacione, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the sqlite_sequence table in the ML Database.
    /// </summary>
    public partial class sqlite_sequence: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<sqlite_sequence> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<sqlite_sequence>(new DAL.MLDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<sqlite_sequence> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(sqlite_sequence item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                sqlite_sequence item=new sqlite_sequence();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<sqlite_sequence> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        DAL.MLDB _db;
        public sqlite_sequence(string connectionString, string providerName) {

            _db=new DAL.MLDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                sqlite_sequence.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<sqlite_sequence>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public sqlite_sequence(){
             _db=new DAL.MLDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public sqlite_sequence(Expression<Func<sqlite_sequence, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<sqlite_sequence> GetRepo(string connectionString, string providerName){
            DAL.MLDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new DAL.MLDB();
            }else{
                db=new DAL.MLDB(connectionString, providerName);
            }
            IRepository<sqlite_sequence> _repo;
            
            if(db.TestMode){
                sqlite_sequence.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<sqlite_sequence>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<sqlite_sequence> GetRepo(){
            return GetRepo("","");
        }
        
        public static sqlite_sequence SingleOrDefault(Expression<Func<sqlite_sequence, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            sqlite_sequence single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static sqlite_sequence SingleOrDefault(Expression<Func<sqlite_sequence, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            sqlite_sequence single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<sqlite_sequence, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<sqlite_sequence, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<sqlite_sequence> Find(Expression<Func<sqlite_sequence, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<sqlite_sequence> Find(Expression<Func<sqlite_sequence, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<sqlite_sequence> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<sqlite_sequence> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<sqlite_sequence> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<sqlite_sequence> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<sqlite_sequence> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<sqlite_sequence> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "name";
        }

        public object KeyValue()
        {
            return this.name;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.name.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(sqlite_sequence)){
                sqlite_sequence compare=(sqlite_sequence)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.name.ToString();
        }

        public string DescriptorColumn() {
            return "name";
        }
        public static string GetKeyColumn()
        {
            return "name";
        }        
        public static string GetDescriptorColumn()
        {
            return "name";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        string _name;
        public string name
        {
            get { return _name; }
            set
            {
                if(_name!=value){
                    _name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _seq;
        public string seq
        {
            get { return _seq; }
            set
            {
                if(_seq!=value){
                    _seq=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="seq");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<sqlite_sequence, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Paises table in the ML Database.
    /// </summary>
    public partial class Paise: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Paise> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Paise>(new DAL.MLDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Paise> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Paise item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Paise item=new Paise();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Paise> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        DAL.MLDB _db;
        public Paise(string connectionString, string providerName) {

            _db=new DAL.MLDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Paise.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Paise>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Paise(){
             _db=new DAL.MLDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Paise(Expression<Func<Paise, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Paise> GetRepo(string connectionString, string providerName){
            DAL.MLDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new DAL.MLDB();
            }else{
                db=new DAL.MLDB(connectionString, providerName);
            }
            IRepository<Paise> _repo;
            
            if(db.TestMode){
                Paise.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Paise>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Paise> GetRepo(){
            return GetRepo("","");
        }
        
        public static Paise SingleOrDefault(Expression<Func<Paise, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Paise single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Paise SingleOrDefault(Expression<Func<Paise, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Paise single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Paise, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Paise, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Paise> Find(Expression<Func<Paise, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Paise> Find(Expression<Func<Paise, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Paise> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Paise> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Paise> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Paise> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Paise> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Paise> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Pais";
        }

        public object KeyValue()
        {
            return this.Pais;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.Pais.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Paise)){
                Paise compare=(Paise)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.Pais.ToString();
        }

        public string DescriptorColumn() {
            return "Pais";
        }
        public static string GetKeyColumn()
        {
            return "Pais";
        }        
        public static string GetDescriptorColumn()
        {
            return "Pais";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        string _Pais;
        public string Pais
        {
            get { return _Pais; }
            set
            {
                if(_Pais!=value){
                    _Pais=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Pais");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Paise, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Estados table in the ML Database.
    /// </summary>
    public partial class Estado: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Estado> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Estado>(new DAL.MLDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Estado> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Estado item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Estado item=new Estado();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Estado> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        DAL.MLDB _db;
        public Estado(string connectionString, string providerName) {

            _db=new DAL.MLDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Estado.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Estado>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Estado(){
             _db=new DAL.MLDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Estado(Expression<Func<Estado, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Estado> GetRepo(string connectionString, string providerName){
            DAL.MLDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new DAL.MLDB();
            }else{
                db=new DAL.MLDB(connectionString, providerName);
            }
            IRepository<Estado> _repo;
            
            if(db.TestMode){
                Estado.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Estado>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Estado> GetRepo(){
            return GetRepo("","");
        }
        
        public static Estado SingleOrDefault(Expression<Func<Estado, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Estado single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Estado SingleOrDefault(Expression<Func<Estado, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Estado single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Estado, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Estado, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Estado> Find(Expression<Func<Estado, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Estado> Find(Expression<Func<Estado, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Estado> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Estado> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Estado> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Estado> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Estado> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Estado> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<long>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.Pais.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Estado)){
                Estado compare=(Estado)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.Pais.ToString();
        }

        public string DescriptorColumn() {
            return "Pais";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Pais";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        long _Id;
        public long Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Pais;
        public string Pais
        {
            get { return _Pais; }
            set
            {
                if(_Pais!=value){
                    _Pais=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Pais");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _State;
        public string State
        {
            get { return _State; }
            set
            {
                if(_State!=value){
                    _State=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="State");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Estado, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Calificaciones table in the ML Database.
    /// </summary>
    public partial class Calificacione: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Calificacione> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Calificacione>(new DAL.MLDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Calificacione> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Calificacione item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Calificacione item=new Calificacione();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Calificacione> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        DAL.MLDB _db;
        public Calificacione(string connectionString, string providerName) {

            _db=new DAL.MLDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Calificacione.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Calificacione>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Calificacione(){
             _db=new DAL.MLDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Calificacione(Expression<Func<Calificacione, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Calificacione> GetRepo(string connectionString, string providerName){
            DAL.MLDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new DAL.MLDB();
            }else{
                db=new DAL.MLDB(connectionString, providerName);
            }
            IRepository<Calificacione> _repo;
            
            if(db.TestMode){
                Calificacione.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Calificacione>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Calificacione> GetRepo(){
            return GetRepo("","");
        }
        
        public static Calificacione SingleOrDefault(Expression<Func<Calificacione, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Calificacione single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Calificacione SingleOrDefault(Expression<Func<Calificacione, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Calificacione single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Calificacione, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Calificacione, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Calificacione> Find(Expression<Func<Calificacione, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Calificacione> Find(Expression<Func<Calificacione, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Calificacione> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Calificacione> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Calificacione> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Calificacione> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Calificacione> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Calificacione> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Calificacion";
        }

        public object KeyValue()
        {
            return this.Calificacion;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.Calificacion.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Calificacione)){
                Calificacione compare=(Calificacione)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.Calificacion.ToString();
        }

        public string DescriptorColumn() {
            return "Calificacion";
        }
        public static string GetKeyColumn()
        {
            return "Calificacion";
        }        
        public static string GetDescriptorColumn()
        {
            return "Calificacion";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        string _Calificacion;
        public string Calificacion
        {
            get { return _Calificacion; }
            set
            {
                if(_Calificacion!=value){
                    _Calificacion=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Calificacion");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Calificacione, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Mensajerias table in the ML Database.
    /// </summary>
    public partial class Mensajeria: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Mensajeria> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Mensajeria>(new DAL.MLDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Mensajeria> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Mensajeria item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Mensajeria item=new Mensajeria();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Mensajeria> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        DAL.MLDB _db;
        public Mensajeria(string connectionString, string providerName) {

            _db=new DAL.MLDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Mensajeria.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Mensajeria>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Mensajeria(){
             _db=new DAL.MLDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Mensajeria(Expression<Func<Mensajeria, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Mensajeria> GetRepo(string connectionString, string providerName){
            DAL.MLDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new DAL.MLDB();
            }else{
                db=new DAL.MLDB(connectionString, providerName);
            }
            IRepository<Mensajeria> _repo;
            
            if(db.TestMode){
                Mensajeria.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Mensajeria>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Mensajeria> GetRepo(){
            return GetRepo("","");
        }
        
        public static Mensajeria SingleOrDefault(Expression<Func<Mensajeria, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Mensajeria single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Mensajeria SingleOrDefault(Expression<Func<Mensajeria, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Mensajeria single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Mensajeria, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Mensajeria, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Mensajeria> Find(Expression<Func<Mensajeria, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Mensajeria> Find(Expression<Func<Mensajeria, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Mensajeria> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Mensajeria> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Mensajeria> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Mensajeria> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Mensajeria> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Mensajeria> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "MensajeriaName";
        }

        public object KeyValue()
        {
            return this.MensajeriaName;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.MensajeriaName.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Mensajeria)){
                Mensajeria compare=(Mensajeria)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.MensajeriaName.ToString();
        }

        public string DescriptorColumn() {
            return "MensajeriaName";
        }
        public static string GetKeyColumn()
        {
            return "MensajeriaName";
        }        
        public static string GetDescriptorColumn()
        {
            return "MensajeriaName";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        string _MensajeriaName;
        public string MensajeriaName
        {
            get { return _MensajeriaName; }
            set
            {
                if(_MensajeriaName!=value){
                    _MensajeriaName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MensajeriaName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Mensajeria, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Busquedas table in the ML Database.
    /// </summary>
    public partial class Busqueda: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Busqueda> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Busqueda>(new DAL.MLDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Busqueda> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Busqueda item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Busqueda item=new Busqueda();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Busqueda> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        DAL.MLDB _db;
        public Busqueda(string connectionString, string providerName) {

            _db=new DAL.MLDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Busqueda.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Busqueda>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Busqueda(){
             _db=new DAL.MLDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Busqueda(Expression<Func<Busqueda, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Busqueda> GetRepo(string connectionString, string providerName){
            DAL.MLDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new DAL.MLDB();
            }else{
                db=new DAL.MLDB(connectionString, providerName);
            }
            IRepository<Busqueda> _repo;
            
            if(db.TestMode){
                Busqueda.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Busqueda>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Busqueda> GetRepo(){
            return GetRepo("","");
        }
        
        public static Busqueda SingleOrDefault(Expression<Func<Busqueda, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Busqueda single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Busqueda SingleOrDefault(Expression<Func<Busqueda, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Busqueda single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Busqueda, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Busqueda, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Busqueda> Find(Expression<Func<Busqueda, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Busqueda> Find(Expression<Func<Busqueda, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Busqueda> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Busqueda> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Busqueda> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Busqueda> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Busqueda> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Busqueda> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Tipo";
        }

        public object KeyValue()
        {
            return this.Tipo;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.Tipo.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Busqueda)){
                Busqueda compare=(Busqueda)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.Tipo.ToString();
        }

        public string DescriptorColumn() {
            return "Tipo";
        }
        public static string GetKeyColumn()
        {
            return "Tipo";
        }        
        public static string GetDescriptorColumn()
        {
            return "Tipo";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        string _Tipo;
        public string Tipo
        {
            get { return _Tipo; }
            set
            {
                if(_Tipo!=value){
                    _Tipo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Tipo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Categoria;
        public string Categoria
        {
            get { return _Categoria; }
            set
            {
                if(_Categoria!=value){
                    _Categoria=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Categoria");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Busqueda, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Usuarios table in the ML Database.
    /// </summary>
    public partial class Usuario: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Usuario> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Usuario>(new DAL.MLDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Usuario> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Usuario item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Usuario item=new Usuario();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Usuario> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        DAL.MLDB _db;
        public Usuario(string connectionString, string providerName) {

            _db=new DAL.MLDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Usuario.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Usuario>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Usuario(){
             _db=new DAL.MLDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Usuario(Expression<Func<Usuario, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Usuario> GetRepo(string connectionString, string providerName){
            DAL.MLDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new DAL.MLDB();
            }else{
                db=new DAL.MLDB(connectionString, providerName);
            }
            IRepository<Usuario> _repo;
            
            if(db.TestMode){
                Usuario.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Usuario>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Usuario> GetRepo(){
            return GetRepo("","");
        }
        
        public static Usuario SingleOrDefault(Expression<Func<Usuario, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Usuario single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Usuario SingleOrDefault(Expression<Func<Usuario, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Usuario single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Usuario, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Usuario, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Usuario> Find(Expression<Func<Usuario, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Usuario> Find(Expression<Func<Usuario, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Usuario> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Usuario> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Usuario> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Usuario> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Usuario> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Usuario> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Seudonimo";
        }

        public object KeyValue()
        {
            return this.Seudonimo;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.Seudonimo.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Usuario)){
                Usuario compare=(Usuario)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.Seudonimo.ToString();
        }

        public string DescriptorColumn() {
            return "Seudonimo";
        }
        public static string GetKeyColumn()
        {
            return "Seudonimo";
        }        
        public static string GetDescriptorColumn()
        {
            return "Seudonimo";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        string _Seudonimo;
        public string Seudonimo
        {
            get { return _Seudonimo; }
            set
            {
                if(_Seudonimo!=value){
                    _Seudonimo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Seudonimo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Mail;
        public string Mail
        {
            get { return _Mail; }
            set
            {
                if(_Mail!=value){
                    _Mail=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Mail");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set
            {
                if(_Nombre!=value){
                    _Nombre=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Nombre");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ApPaterno;
        public string ApPaterno
        {
            get { return _ApPaterno; }
            set
            {
                if(_ApPaterno!=value){
                    _ApPaterno=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ApPaterno");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ApMaterno;
        public string ApMaterno
        {
            get { return _ApMaterno; }
            set
            {
                if(_ApMaterno!=value){
                    _ApMaterno=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ApMaterno");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Direccion;
        public string Direccion
        {
            get { return _Direccion; }
            set
            {
                if(_Direccion!=value){
                    _Direccion=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Direccion");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CP;
        public string CP
        {
            get { return _CP; }
            set
            {
                if(_CP!=value){
                    _CP=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CP");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Colonia;
        public string Colonia
        {
            get { return _Colonia; }
            set
            {
                if(_Colonia!=value){
                    _Colonia=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Colonia");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Tel_Casa;
        public string Tel_Casa
        {
            get { return _Tel_Casa; }
            set
            {
                if(_Tel_Casa!=value){
                    _Tel_Casa=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Tel_Casa");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Tel_Cel;
        public string Tel_Cel
        {
            get { return _Tel_Cel; }
            set
            {
                if(_Tel_Cel!=value){
                    _Tel_Cel=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Tel_Cel");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Pais;
        public string Pais
        {
            get { return _Pais; }
            set
            {
                if(_Pais!=value){
                    _Pais=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Pais");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Estado;
        public string Estado
        {
            get { return _Estado; }
            set
            {
                if(_Estado!=value){
                    _Estado=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Estado");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Ciudad;
        public string Ciudad
        {
            get { return _Ciudad; }
            set
            {
                if(_Ciudad!=value){
                    _Ciudad=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Ciudad");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _FchAlta;
        public string FchAlta
        {
            get { return _FchAlta; }
            set
            {
                if(_FchAlta!=value){
                    _FchAlta=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="FchAlta");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Usuario, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the MenuPrincipal table in the ML Database.
    /// </summary>
    public partial class MenuPrincipal: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<MenuPrincipal> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<MenuPrincipal>(new DAL.MLDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<MenuPrincipal> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(MenuPrincipal item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                MenuPrincipal item=new MenuPrincipal();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<MenuPrincipal> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        DAL.MLDB _db;
        public MenuPrincipal(string connectionString, string providerName) {

            _db=new DAL.MLDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                MenuPrincipal.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<MenuPrincipal>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public MenuPrincipal(){
             _db=new DAL.MLDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public MenuPrincipal(Expression<Func<MenuPrincipal, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<MenuPrincipal> GetRepo(string connectionString, string providerName){
            DAL.MLDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new DAL.MLDB();
            }else{
                db=new DAL.MLDB(connectionString, providerName);
            }
            IRepository<MenuPrincipal> _repo;
            
            if(db.TestMode){
                MenuPrincipal.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<MenuPrincipal>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<MenuPrincipal> GetRepo(){
            return GetRepo("","");
        }
        
        public static MenuPrincipal SingleOrDefault(Expression<Func<MenuPrincipal, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            MenuPrincipal single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static MenuPrincipal SingleOrDefault(Expression<Func<MenuPrincipal, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            MenuPrincipal single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<MenuPrincipal, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<MenuPrincipal, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<MenuPrincipal> Find(Expression<Func<MenuPrincipal, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<MenuPrincipal> Find(Expression<Func<MenuPrincipal, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<MenuPrincipal> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<MenuPrincipal> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<MenuPrincipal> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<MenuPrincipal> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<MenuPrincipal> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<MenuPrincipal> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id_Menu";
        }

        public object KeyValue()
        {
            return this.Id_Menu;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<long>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.Opciontxt.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(MenuPrincipal)){
                MenuPrincipal compare=(MenuPrincipal)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.Opciontxt.ToString();
        }

        public string DescriptorColumn() {
            return "Opciontxt";
        }
        public static string GetKeyColumn()
        {
            return "Id_Menu";
        }        
        public static string GetDescriptorColumn()
        {
            return "Opciontxt";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        long _Id_Menu;
        public long Id_Menu
        {
            get { return _Id_Menu; }
            set
            {
                if(_Id_Menu!=value){
                    _Id_Menu=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id_Menu");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Opciontxt;
        public string Opciontxt
        {
            get { return _Opciontxt; }
            set
            {
                if(_Opciontxt!=value){
                    _Opciontxt=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Opciontxt");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<MenuPrincipal, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Transacciones table in the ML Database.
    /// </summary>
    public partial class Transaccione: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Transaccione> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Transaccione>(new DAL.MLDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Transaccione> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Transaccione item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Transaccione item=new Transaccione();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Transaccione> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        DAL.MLDB _db;
        public Transaccione(string connectionString, string providerName) {

            _db=new DAL.MLDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Transaccione.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Transaccione>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Transaccione(){
             _db=new DAL.MLDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Transaccione(Expression<Func<Transaccione, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Transaccione> GetRepo(string connectionString, string providerName){
            DAL.MLDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new DAL.MLDB();
            }else{
                db=new DAL.MLDB(connectionString, providerName);
            }
            IRepository<Transaccione> _repo;
            
            if(db.TestMode){
                Transaccione.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Transaccione>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Transaccione> GetRepo(){
            return GetRepo("","");
        }
        
        public static Transaccione SingleOrDefault(Expression<Func<Transaccione, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Transaccione single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Transaccione SingleOrDefault(Expression<Func<Transaccione, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Transaccione single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Transaccione, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Transaccione, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Transaccione> Find(Expression<Func<Transaccione, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Transaccione> Find(Expression<Func<Transaccione, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Transaccione> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Transaccione> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Transaccione> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Transaccione> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Transaccione> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Transaccione> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id_Tran";
        }

        public object KeyValue()
        {
            return this.Id_Tran;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<long>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.FchAlta.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Transaccione)){
                Transaccione compare=(Transaccione)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.FchAlta.ToString();
        }

        public string DescriptorColumn() {
            return "FchAlta";
        }
        public static string GetKeyColumn()
        {
            return "Id_Tran";
        }        
        public static string GetDescriptorColumn()
        {
            return "FchAlta";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        long _Id_Tran;
        public long Id_Tran
        {
            get { return _Id_Tran; }
            set
            {
                if(_Id_Tran!=value){
                    _Id_Tran=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id_Tran");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _FchAlta;
        public string FchAlta
        {
            get { return _FchAlta; }
            set
            {
                if(_FchAlta!=value){
                    _FchAlta=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="FchAlta");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Seudonimo;
        public string Seudonimo
        {
            get { return _Seudonimo; }
            set
            {
                if(_Seudonimo!=value){
                    _Seudonimo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Seudonimo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Tipo_Op;
        public string Tipo_Op
        {
            get { return _Tipo_Op; }
            set
            {
                if(_Tipo_Op!=value){
                    _Tipo_Op=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Tipo_Op");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _FchCompraVenta;
        public string FchCompraVenta
        {
            get { return _FchCompraVenta; }
            set
            {
                if(_FchCompraVenta!=value){
                    _FchCompraVenta=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="FchCompraVenta");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Dsc;
        public string Dsc
        {
            get { return _Dsc; }
            set
            {
                if(_Dsc!=value){
                    _Dsc=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Dsc");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Estatus;
        public string Estatus
        {
            get { return _Estatus; }
            set
            {
                if(_Estatus!=value){
                    _Estatus=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Estatus");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Calif_Recib;
        public string Calif_Recib
        {
            get { return _Calif_Recib; }
            set
            {
                if(_Calif_Recib!=value){
                    _Calif_Recib=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Calif_Recib");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Calif_Otorg;
        public string Calif_Otorg
        {
            get { return _Calif_Otorg; }
            set
            {
                if(_Calif_Otorg!=value){
                    _Calif_Otorg=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Calif_Otorg");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Mensajeria;
        public string Mensajeria
        {
            get { return _Mensajeria; }
            set
            {
                if(_Mensajeria!=value){
                    _Mensajeria=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Mensajeria");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _NumGuia;
        public string NumGuia
        {
            get { return _NumGuia; }
            set
            {
                if(_NumGuia!=value){
                    _NumGuia=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NumGuia");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _Cantidad;
        public double? Cantidad
        {
            get { return _Cantidad; }
            set
            {
                if(_Cantidad!=value){
                    _Cantidad=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Cantidad");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _Precio;
        public double? Precio
        {
            get { return _Precio; }
            set
            {
                if(_Precio!=value){
                    _Precio=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Precio");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double _PrecioEnvio;
        public double PrecioEnvio
        {
            get { return _PrecioEnvio; }
            set
            {
                if(_PrecioEnvio!=value){
                    _PrecioEnvio=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PrecioEnvio");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _Total;
        public double? Total
        {
            get { return _Total; }
            set
            {
                if(_Total!=value){
                    _Total=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Total");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Transaccione, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
}
