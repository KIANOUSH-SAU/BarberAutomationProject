import { useState } from "react";
import { githubImg, easterEggImg } from "../assets/assetsHandler";
const Footer = () => {
	const [showEasterEgg, setShowEasterEgg] = useState(false);
	let counter = 0;
	function handleClick() {
		counter++;
		console.log(counter);
		if (counter === 5) {
			setShowEasterEgg(true);
			counter = 0;
			setTimeout(() => setShowEasterEgg(false), 1500);
		}
	}
	return (
		<footer className="shadow-sm bg-blue-950">
			{showEasterEgg && (
				<>
					<div className="fixed inset-0 bg-black/90 pointer-events-none" />
					<div className="fixed inset-0 flex items-center justify-center pointer-events-none">
						<div>
							<img
								src={easterEggImg}
								alt="Easter Egg"
								className="w-180 h-full"
							/>
						</div>
					</div>
				</>
			)}
			<div className="w-full mx-auto max-w-screen-xl p-4 md:flex md:items-center md:justify-between">
				<span className="text-sm text-gray-500 sm:text-center dark:text-gray-400">
					<button onClick={handleClick}>
						KIANOUSH-SAU G221210571
					</button>
				</span>
				<ul className="flex flex-wrap items-center mt-3 text-sm font-medium text-gray-500 dark:text-gray-400 sm:mt-0">
					<li>
						<a
							href="https://github.com/KIANOUSH-SAU/BarberAutomationProject"
							className="hover:underline"
							target="_blank"
						>
							<img
								src={githubImg}
								alt="GitHub"
								className="w-10 h-10"
							/>
						</a>
					</li>
				</ul>
			</div>
		</footer>
	);
};

export default Footer;
