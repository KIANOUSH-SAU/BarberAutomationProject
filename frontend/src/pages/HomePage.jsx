import { Link } from "react-router-dom";
import { homeBackground } from "../assets/assetsHandler";

const HomePage = () => {
	return (
		<div
			className="min-h-screen flex flex-col items-center justify-center bg-cover bg-center bg-no-repeat relative"
			style={{
				backgroundImage: `url(${homeBackground})`,
			}}
		>
			{/* Dark overlay for better text readability */}
			<div className="absolute inset-0 bg-black/50"></div>

			{/* Content */}
			<div className="text-center relative z-10">
				<h1 className="text-6xl font-bold text-white mb-4 drop-shadow-lg">
					💈 Barber Shop
				</h1>
				<p className="text-xl text-amber-100 mb-8">
					Welcome to our professional barber shop
				</p>
				<div className="space-x-4">
					<Link
						to="/services"
						className="inline-block px-8 py-3 bg-amber-600 text-white rounded-lg hover:bg-amber-700 transition shadow-lg"
					>
						View Services
					</Link>
					<Link
						to="/appointments"
						className="inline-block px-8 py-3 bg-amber-800 text-white rounded-lg hover:bg-amber-900 transition shadow-lg"
					>
						Book Appointment
					</Link>
				</div>
			</div>
		</div>
	);
};

export default HomePage;
