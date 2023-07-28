import logo from './assets/logo.svg'

function Header() {
    return (
        <>
            <div className="header bg-teal-500 p-4 flex items-center">
                <div className="logo mr-4">
                    <img className="h-8 w-8" src={logo} alt="Logo" />
                </div>

                <div className="servicename text-white font-bold">
                    Farmers Market For All
                </div>
            </div>
        </>
    );
}

export default Header;