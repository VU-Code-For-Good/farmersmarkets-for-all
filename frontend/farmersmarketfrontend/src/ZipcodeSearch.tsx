import React from 'react';
import stateziplookup from './assets/stateziplookup.json';

interface ZipcodeSearchProps {
    selectedState: string | null;
}

const lookupZipcodes = (selectedState: string) => {
    return stateziplookup
        .filter((zip) => zip.STATE === selectedState)
        .map((zip) => zip.ZIP);
};

const ZipcodeSearch: React.FC<ZipcodeSearchProps> = (props) => {
    const { selectedState } = props;
    const applicableZipcodes = lookupZipcodes(selectedState || '');

    return (
        <div>
            <div className = "inline-block">
                <label htmlFor="zipcodesDropdown" className="block mt-4">
                    Select by Zipcode:
                </label>
                <select
                    id="zipcodesDropdown"
                    className="border rounded p-2 w-full"
                    defaultValue="" // Set the default value to an empty string
                >
                    <option value="" disabled>
                        Select a Zipcode
                    </option>
                    {applicableZipcodes.map((zipcode) => (
                        <option key={zipcode} value={zipcode}>
                            {zipcode}
                        </option>
                    ))}
                </select>
            </div>

            <div className = "ml-4 text-white inline-block">

                <button className="bg-teal-500 px-2 py-2 rounded ">
                    Search
                </button>
            </div>

        </div>
    );
};

export default ZipcodeSearch;
