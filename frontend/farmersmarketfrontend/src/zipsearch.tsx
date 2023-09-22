import React, { Component } from "react";
import { useForm } from "react-hook-form";

interface StateData {
    zipcode: string;
    error: string;
}

interface ZipSearchProps {
    onSubmit: (zipcode: string) => void;
}

class ZipSearch extends Component<any, StateData> {
    constructor(props: ZipSearchProps) {
        super(props);
        this.state = {
            zipcode: "",
            error: "",
        };
    }

    handleInputChange = (event) => {
        this.setState({
            zipcode: event.target.value,
            error: "",
        });
    };

    handleSubmit = (event) => {
        event.preventDefault();
        const { zipcode } = this.state;

        if (!zipcode.match(/^\d{5}(?:[-\s]\d{4})?$/)) {
            this.setState({
                error: "Invalid zip code",
            });
        } else {
            this.props.onSubmit(zipcode);
        }
    };

    render() {
        const { zipcode, error } = this.state;

        return (
            <form onSubmit={this.handleSubmit} className="mx-2 mb-4">
                <div className="inline-flex w-full items-center space-x-4">
                    <label htmlFor="zipcode" className="block text-gray-700 font-bold w-24">
                        Zip Code
                    </label>
                    <input
                        type="text"
                        id="zipcode"
                        name="zipcode"
                        value={zipcode}
                        onChange={this.handleInputChange}
                        className="flex-grow shadow appearance-none border rounded py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                    />
                    <button className="bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" type="submit">
                        Search
                    </button>
                </div>
                {error && <span className="text-red-500 mt-2">{error}</span>}
            </form>



        );
    }
}

export default ZipSearch;