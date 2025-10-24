import { barberPlaceholderImg } from "../assets/assetsHandler";
import { useState } from "react";

const BarberCard = ({ barber }) => {
	const [isDropdownOpen, setIsDropdownOpen] = useState(false);

	const toggleDropdown = () => {
		setIsDropdownOpen(!isDropdownOpen);
	};

	return (
		<div className="max-w-sm border border-red-700 rounded-lg shadow-sm bg-blue-950">
			<img
				className="rounded-t-lg p-2 bg-white"
				src={barberPlaceholderImg}
				alt=""
			/>
			<div className="p-5">
				<h5 className="mb-2 text-2xl font-bold tracking-tight text-white">
					{barber.name}
				</h5>
				<div className="flex gap-3 items-center">
					<div className="bg-blue-600 rounded-full p-1">
						<svg
							className="w-5 h-5 text-white"
							fill="currentColor"
							viewBox="0 0 24 24"
							xmlns="http://www.w3.org/2000/svg"
						>
							<path d="M6.62 10.79a15.053 15.053 0 006.59 6.59l2.2-2.2a.996.996 0 011.11-.27c1.12.45 2.33.69 3.57.69.55 0 1 .45 1 1V20c0 .55-.45 1-1 1-9.39 0-17-7.61-17-17 0-.55.45-1 1-1h3.5c.55 0 1 .45 1 1 0 1.25.24 2.45.69 3.57.14.37.08.79-.27 1.11l-2.2 2.2z" />
						</svg>
					</div>

					<p className="mb-3 font-normal text-gray-700 dark:text-gray-400">
						{barber.phoneNumber}
					</p>
				</div>

				<button
					onClick={toggleDropdown}
					className="text-white bg-blue-700 hover:bg-blue-800 
                    focus:ring-4 focus:outline-none focus:ring-blue-300 
                    font-medium rounded-lg text-sm px-5 py-2.5 text-center 
                    inline-flex items-center dark:bg-blue-600
                    dark:hover:bg-blue-700 dark:focus:ring-blue-800"
					type="button"
				>
					Dropdown button{" "}
					<svg
						className="w-2.5 h-2.5 ms-3"
						aria-hidden="true"
						xmlns="http://www.w3.org/2000/svg"
						fill="none"
						viewBox="0 0 10 6"
					>
						<path
							stroke="currentColor"
							strokeLinecap="round"
							strokeLinejoin="round"
							strokeWidth="2"
							d="m1 1 4 4 4-4"
						/>
					</svg>
				</button>

				{isDropdownOpen && (
					<div className="z-10 bg-white divide-y divide-gray-100 rounded-lg shadow-sm w-44 dark:bg-gray-700 mt-2">
						<ul
							className="py-2 text-sm text-gray-700 dark:text-gray-200"
							aria-labelledby="dropdownDefaultButton"
						>
							<li className="block px-4 py-2 cursor-default">
								Dashboard
							</li>
							<li className="block px-4 py-2 cursor-default">
								Settings
							</li>
							<li className="block px-4 py-2 cursor-default">
								Earnings
							</li>
							<li className="block px-4 py-2 cursor-default">
								Sign out
							</li>
						</ul>
					</div>
				)}
			</div>
		</div>
	);
};

export default BarberCard;
