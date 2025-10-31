import { Link } from "react-router-dom";
import { adminIcon } from "../assets/assetsHandler";
import { useEffect, useState } from "react";

const Navbar = () => {
	const [isLoggedIn, setIsLoggedIn] = useState(false);

	useEffect(() => {
		const checkLoginStatus = () => {
			const token = localStorage.getItem("authToken");
			setIsLoggedIn(!!token);
		};

		// Check on mount
		checkLoginStatus();

		// Listen for storage changes (when logging in/out in same tab)
		window.addEventListener("storage", checkLoginStatus);

		// Custom event for same-tab updates
		window.addEventListener("authChange", checkLoginStatus);

		return () => {
			window.removeEventListener("storage", checkLoginStatus);
			window.removeEventListener("authChange", checkLoginStatus);
		};
	}, []);

	function handleLogOut() {
		localStorage.removeItem("authToken");
		localStorage.removeItem("user");
		setIsLoggedIn(false);
		// Dispatch custom event for same-tab update
		window.dispatchEvent(new Event("authChange"));
		window.location.href = "/";
	}
	return (
		<nav className="fixed z-20 w-full bg-blue-950">
			<div className="max-w-screen-xl flex items-center justify-center mx-auto p-4 relative">
				<div className="flex md:order-2">
					<button
						data-collapse-toggle="navbar-search"
						type="button"
						className="inline-flex items-center p-2 w-10 h-10 justify-center text-sm text-gray-500 rounded-lg md:hidden hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-gray-200 dark:text-gray-400 dark:hover:bg-gray-700 dark:focus:ring-gray-600"
						aria-controls="navbar-search"
						aria-expanded="false"
					>
						<span className="sr-only">Open main menu</span>
						<svg
							className="w-5 h-5"
							aria-hidden="true"
							xmlns="http://www.w3.org/2000/svg"
							fill="none"
							viewBox="0 0 17 14"
						>
							<path
								stroke="currentColor"
								strokeLinecap="round"
								strokeLinejoin="round"
								strokeWidth="2"
								d="M1 1h15M1 7h15M1 13h15"
							/>
						</svg>
					</button>
				</div>
				<div className="items-center hidden w-auto md:flex">
					<div className="relative mt-3 md:hidden">
						<div className="absolute inset-y-0 start-0 flex items-center ps-3 pointer-events-none">
							<svg
								className="w-4 h-4 text-gray-500 dark:text-gray-400"
								aria-hidden="true"
								xmlns="http://www.w3.org/2000/svg"
								fill="none"
								viewBox="0 0 20 20"
							>
								<path
									stroke="currentColor"
									strokeLinecap="round"
									strokeLinejoin="round"
									strokeWidth="2"
									d="m19 19-4-4m0-7A7 7 0 1 1 1 8a7 7 0 0 1 14 0Z"
								/>
							</svg>
						</div>
						<input
							type="text"
							id="search-navbar"
							className="block w-full p-2 ps-10 text-sm text-gray-900 border border-gray-300 rounded-lg bg-gray-50 focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
							placeholder="Search..."
						/>
					</div>
					<ul className="inline-flex flex-col p-4 md:p-0 mt-4 font-medium border md:space-x-8 rtl:space-x-reverse md:flex-row md:mt-0 md:border-0 text-white">
						<li>
							{isLoggedIn ? (
								<Link
									to="/employees"
									className="btn-type-2 justify-center"
									style={{
										borderBottomRightRadius: "25px",
										borderBottomLeftRadius: "25px",
									}}
								>
									Çalışanlar
								</Link>
							) : (
								<Link
									to="/"
									className="btn-type-2 justify-center"
									style={{
										borderBottomRightRadius: "25px",
										borderBottomLeftRadius: "25px",
									}}
								>
									Ana Sayfa
								</Link>
							)}
						</li>
						<li>
							{isLoggedIn ? (
								<Link
									to="/services-management"
									className="btn-type-2 justify-center"
									style={{
										borderBottomRightRadius: "25px",
										borderBottomLeftRadius: "25px",
									}}
								>
									Hizmet Yönetimi
								</Link>
							) : (
								<Link
									to="/services"
									className="btn-type-2 justify-center"
									style={{
										borderBottomRightRadius: "25px",
										borderBottomLeftRadius: "25px",
									}}
								>
									Hizmetlerimiz
								</Link>
							)}
						</li>
						<li>
							<Link
								to="/login"
								className="btn-type-3 justify-center"
								style={{
									borderBottomRightRadius: "25px",
									borderBottomLeftRadius: "25px",
								}}
							>
								Yönetici Girişi
								<img
									src={adminIcon}
									alt=""
									className="w-5 h-5"
								/>
							</Link>
						</li>
					</ul>
				</div>
				{isLoggedIn && (
					<button
						className="bg-red-400 rounded-full p-3 border-2 border-red-50 hidden md:block absolute right-0 cursor-pointer hover:bg-red-600"
						onClick={handleLogOut}
					>
						<svg
							fill="#ffffff"
							version="1.1"
							id="Layer_1"
							xmlns="http://www.w3.org/2000/svg"
							xmlns:xlink="http://www.w3.org/1999/xlink"
							width="20px"
							height="20px"
							viewBox="0 0 70 70"
							enable-background="new 0 0 70 70"
							xml:space="preserve"
							stroke="#ffffff"
						>
							<g id="SVGRepo_bgCarrier" stroke-width="0"></g>
							<g
								id="SVGRepo_tracerCarrier"
								stroke-linecap="round"
								stroke-linejoin="round"
							></g>
							<g id="SVGRepo_iconCarrier">
								{" "}
								<g>
									{" "}
									<path d="M62.666,32.316L57.758,21.53c-0.457-1.007-1.646-1.449-2.648-0.992c-1.006,0.457-1.45,1.644-0.992,2.648l3.365,7.397 H44.481c-1.104,0-2,0.896-2,2s0.896,2,2,2h13.69l-4.055,8.912c-0.458,1.004-0.014,2.191,0.992,2.648 c0.269,0.121,0.55,0.18,0.827,0.18c0.76,0,1.486-0.436,1.821-1.172l4.939-10.855c0.104-0.196,0.172-0.407,0.206-0.625 C62.988,33.207,62.901,32.726,62.666,32.316z"></path>{" "}
									<path d="M51.583,47.577c-1.104,0-2,0.895-2,2v8.006h-11V15.269c0-1.722-0.81-3.25-2.445-3.795L24.536,7.583h25.047v9.994 c0,1.104,0.896,2,2,2s2-0.896,2-2v-12c0-1.104,0.003-1.994-1.102-1.994H12.609l-0.325-0.109c-0.413-0.138-0.694-0.205-1.119-0.205 c-0.829,0-1.94,0.258-2.63,0.755C7.492,4.776,6.583,5.983,6.583,7.269v47.572c0,1.721,1.393,3.25,3.026,3.795l24.146,8 c0.413,0.137,0.913,0.205,1.337,0.205c0.83,0,1.395-0.258,2.084-0.756c1.043-0.752,1.407-1.959,1.407-3.244v-1.258h13.898 c1.104,0,1.102-0.902,1.102-2.006v-10C53.583,48.472,52.688,47.577,51.583,47.577z M34.583,62.841l-24-8V7.583V7.504L10.8,7.345 l23.783,7.924V62.841z"></path>{" "}
									<path d="M30.583,47.577c0.553,0,1-0.447,1-1v-6c0-0.553-0.447-1-1-1s-1,0.447-1,1v6C29.583,47.13,30.03,47.577,30.583,47.577z"></path>{" "}
								</g>{" "}
							</g>
						</svg>
					</button>
				)}
			</div>
		</nav>
	);
};

export default Navbar;
