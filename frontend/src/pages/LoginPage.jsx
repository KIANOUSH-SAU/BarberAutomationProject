import { useRef } from "react";
import { loginBg } from "../assets/assetsHandler";
import { Link, useNavigate } from "react-router-dom";

const LoginPage = () => {
	const navigate = useNavigate();
	const emailRef = useRef();
	const passwordRef = useRef();
	// Login function
	async function login(email, password) {
		const response = await fetch("https://localhost:7261/api/auth/login", {
			method: "POST",
			headers: { "Content-Type": "application/json" },
			body: JSON.stringify({ email, password }),
		});

		const data = await response.json();

		if (response.ok) {
			// Store token in localStorage
			localStorage.setItem("authToken", data.token);
			localStorage.setItem(
				"user",
				JSON.stringify({
					email: data.email,
					firstName: data.firstName,
					lastName: data.lastName,
				})
			);
			navigate("/appointments");
		}
	}

	// Use token in API calls
	async function getServices() {
		const token = localStorage.getItem("authToken");

		const response = await fetch("https://localhost:7261/api/services", {
			headers: {
				Authorization: `Bearer ${token}`,
			},
		});

		return response.json();
	}
	function handleSubmit(e) {
		e.preventDefault();
		try {
			login(emailRef.current.value, passwordRef.current.value);
		} catch (error) {
			console.log("Problems with the login function:" + error);
		}
	}
	return (
		<div className="min-h-screen max-h-screen flex flex-col items-center justify-center relative overflow-hidden">
			<div
				className="fixed inset-0 bg-cover bg-center bg-no-repeat bg-animation"
				style={{
					backgroundImage: `url(${loginBg})`,
				}}
			></div>
			<div className="absolute inset-0 bg-black/40"></div>

			<div className="text-center relative z-10 glass-bg rounded-3xl p-20 max-w-3xl mx-4">
				<h1 className="text-6xl font-bold text-white mb-4 drop-shadow-lg">
					Giriş
				</h1>
				<form className="flex flex-col gap-5" onSubmit={handleSubmit}>
					<input type="text" className="bg-amber-50" ref={emailRef} />
					<input
						type="password"
						className="bg-amber-50"
						ref={passwordRef}
					/>
					<button type="submit">Giriş Yap</button>
				</form>
				<div className="space-x-4"></div>
			</div>
		</div>
	);
};

export default LoginPage;
