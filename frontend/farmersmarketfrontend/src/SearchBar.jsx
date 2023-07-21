function SearchBar() {
    return (
      <div className="mx-8 w-full">
        <div className="flex items-center justify-end border rounded-md p-2">
          <input
            type="text"
            placeholder="Search..."
            className="flex-1 px-2 py-1 rounded-md border-none focus:outline-none"
          />
          <button className="ml-2 bg-blue-500 text-white px-4 py-2 rounded-md">
            Search
          </button>
        </div>
  
        <div className="mt-4 flex items-center justify-end">
          <label className="inline-flex items-center">
            <input
              type="radio"
              name="searchOption"
              value="byState"
              className="form-radio h-5 w-5 text-blue-600"
            />
            <span className="ml-2 text-gray-700">By State</span>
          </label>
          <label className="inline-flex items-center ml-6">
            <input
              type="radio"
              name="searchOption"
              value="byZipcode"
              className="form-radio h-5 w-5 text-blue-600"
            />
            <span className="ml-2 text-gray-700">By Zipcode</span>
          </label>
        </div>
      </div>
    );
  }
  
  export default SearchBar;