import SplashingItems from "../animations/SplashingItems";

const AlreadyLoggedInPage = () => {
	return (
		<>
			<SplashingItems />
			<div className="min-h-screen bg-gray-900 flex items-center justify-center p-4">
				<div className="relative z-10 bg-blue-950 rounded-3xl p-20 max-w-3xl mx-4 border-4 border-dashed border-white">
					<h1 className="text-gray-50 text-xl font-bold text-center">
						You're already logged in
					</h1>
				</div>
			</div>
		</>
	);
};

export default AlreadyLoggedInPage;
