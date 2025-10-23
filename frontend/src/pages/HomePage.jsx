import { Link } from "react-router-dom";
import { homeBackground } from "../assets/assetsHandler";
import gsap from "gsap";
import { useGSAP } from "@gsap/react";
const HomePage = () => {
	useGSAP(() => {
		// Subtle zoom and pan animation for background
		gsap.to(".bg-animation", {
			scale: 1.1,
			duration: 20,
			ease: "power1.inOut",
			repeat: -1,
			yoyo: true,
		});
		const glassContainer = document.querySelector(".glass-bg");

		gsap.to(glassContainer, {
			scale: 1.05,
			duration: 10,
			yoyo: true,
			repeat: -1,
		});

		glassContainer.addEventListener("mouseenter", () => {
			gsap.to(glassContainer, {
				backgroundColor: "rgba(0, 0, 0, 0.25)", // Brighter on hover
				duration: 0.4,
				ease: "power2.out",
			});
		});
		glassContainer.addEventListener("mouseleave", () => {
			gsap.to(glassContainer, {
				backgroundColor: "rgba(255, 255, 255, 0.05)", // Matches your CSS
				duration: 0.4,
				ease: "power2.out",
			});
		});
	}, []);
	return (
		<div className="min-h-screen max-h-screen flex flex-col items-center justify-center relative overflow-hidden">
			{/* Animated background layer */}
			<div
				className="absolute inset-0 bg-cover bg-center bg-no-repeat bg-animation"
				style={{
					backgroundImage: `url(${homeBackground})`,
				}}
			></div>

			{/* Dark overlay */}
			<div className="absolute inset-0 bg-black/40"></div>

			<div className="text-center relative z-10 glass-bg rounded-3xl p-20 max-w-3xl mx-4">
				<h1 className="text-6xl font-bold text-white mb-4 drop-shadow-lg">
					Hoş Geldiniz
				</h1>
				<p className="text-xl text-white/90 mb-8">
					Müşteriler kolayca randevu alabilir ve işletmeler randevu
					takibi yapabilir.
				</p>
				<div className="space-x-4">
					<Link to="/services" className="btn-type-2">
						Hizmetlerimiz
					</Link>
					<Link
						to="/appointments"
						className="btn-type-3 justify-center"
					>
						Yönetici Girişi
					</Link>
				</div>
			</div>
		</div>
	);
};

export default HomePage;
