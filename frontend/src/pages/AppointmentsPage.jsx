import { Link } from "react-router-dom";

const AppointmentsPage = () => {
	return (
		<div className="min-h-screen bg-stone-100">
			<nav className="bg-amber-900 text-white p-4 mb-8">
				<Link to="/" className="hover:text-amber-200">
					← Back to Home
				</Link>
			</nav>
			<div className="container mx-auto px-4">
				<h1 className="text-large-title mb-8">Book an Appointment</h1>
				<div className="max-w-2xl mx-auto bg-white p-8 rounded-lg shadow-lg">
					<form className="space-y-6">
						<div>
							<label className="block text-amber-900 font-semibold mb-2">
								Your Name
							</label>
							<input
								type="text"
								className="w-full px-4 py-2 border border-amber-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-amber-600"
								placeholder="John Doe"
							/>
						</div>
						<div>
							<label className="block text-amber-900 font-semibold mb-2">
								Phone Number
							</label>
							<input
								type="tel"
								className="w-full px-4 py-2 border border-amber-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-amber-600"
								placeholder="+1 234 567 8900"
							/>
						</div>
						<div>
							<label className="block text-amber-900 font-semibold mb-2">
								Select Service
							</label>
							<select className="w-full px-4 py-2 border border-amber-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-amber-600">
								<option>Choose a service...</option>
								<option>Haircut</option>
								<option>Beard Trim</option>
								<option>Shave</option>
							</select>
						</div>
						<div>
							<label className="block text-amber-900 font-semibold mb-2">
								Preferred Date & Time
							</label>
							<input
								type="datetime-local"
								className="w-full px-4 py-2 border border-amber-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-amber-600"
							/>
						</div>
						<button
							type="submit"
							className="w-full bg-amber-600 text-white py-3 rounded-lg hover:bg-amber-700 transition font-semibold text-lg"
						>
							Book Appointment
						</button>
					</form>
				</div>
			</div>
		</div>
	);
};

export default AppointmentsPage;
