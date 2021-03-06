﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;

namespace ScaleAndRotate
{
    class HomePage : ContentPage
    {
        public HomePage()
        {
            Command<Type> navigateCommand = 
                new Command<Type>(async (Type pageType) =>
                {
                    if (pageType == null)
                    {
                        await this.DisplayAlert("ScaleAndRotate", 
                                    "Page not yet implemented", "OK", null);
                        return;
                    }

                    // Get all the constructors of the page type.
                    IEnumerable<ConstructorInfo> constructors = 
                            pageType.GetTypeInfo().DeclaredConstructors;

                    foreach (ConstructorInfo constructor in constructors)
                    {
                        // Check if the constructor has no parameters.
                        if (constructor.GetParameters().Length == 0)
                        {
                            // If so, instantiate it, and navigate to it.
                            Page page = (Page)constructor.Invoke(null);
                            await this.Navigation.PushAsync(page);
                            break;
                        }
                    }
                });

            this.Title = "Scale and Rotate";

            this.Content = new TableView
                {
                    Intent = TableIntent.Menu,
                    Root = new TableRoot
                    {
                        new TableSection()
                        {
                            new TextCell
                            {
                                Text = "Scale",
                                Command = navigateCommand,
                                CommandParameter = typeof(ScaleDemoPage)
                            },

                            new TextCell
                            {
                                Text = "Rotation",
                                Command = navigateCommand,
                                CommandParameter = typeof(RotationDemoPage)
                            },

                            new TextCell
                            {
                                Text = "RotationX",
                                Command = navigateCommand,
                                CommandParameter = typeof(RotationXDemoPage)
                            },

                            new TextCell
                            {
                                Text = "RotationY",
                                Command = navigateCommand,
                                CommandParameter = typeof(RotationYDemoPage)
                            }
                        }
                    }
                };
        }
    }
}
